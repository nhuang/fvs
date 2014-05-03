using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using RestSharp;
using System.Net;
using System.Text;
using FestivalScheduler.Models.Resouces;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace FestivalScheduler.Models.DataResource
{
    public class DataIOService
    {

        private fschedulerEntities db;
        private string artistFile = "ArtistData.json";
        private string artistFilePath = "";
        private int recordCount = 0;
        public DataIOService(fschedulerEntities context)
        {
            db = context;
        }

        public DataIOService()
            : this(new fschedulerEntities())
        {
        }

        public string ProcessImportArtistData(string username, string password)
        {
            string result = "";

            result = ImportArtistDataFromService(username, password);
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }

            result = InsertOrUpdateArtistInDb();
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }

            //ConvertToKeyDisplayMapping();

            PDFService pdf = new PDFService();
            pdf.GenerateAgendaPDF();
            result = string.Format("Processed {0} records success.", recordCount);
            return result;
        }
        public string ImportArtistDataFromService(string username, string password)
        {
            try
            {
                string requestUrl = "https://www.fringetheatre.ca/admin2014/artist_data_export_json.php";

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(requestUrl);
                string usernamePassword = username + ":" + password;
                myReq.Timeout = 20000;
                myReq.UserAgent = "SchedulerSystem";
                //Use the CredentialCache so we can attach the authentication to the request
                CredentialCache mycache = new CredentialCache();
                //this perform Basic authorize
                mycache.Add(new Uri(requestUrl), "Basic", new NetworkCredential(username, password));
                myReq.Credentials = mycache;
                myReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));
                //Send and receive the response
                WebResponse wr = myReq.GetResponse();
                Stream receiveStream = wr.GetResponseStream();
                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                artistFilePath = HttpContext.Current.Server.MapPath("~/File/Resource/") + artistFile;
                //write string to file
                System.IO.File.WriteAllText(artistFilePath, reader.ReadToEnd());
            }
            catch (Exception)
            {
                return "Import data from web service fail, please check your username/password";
            }
            return "";
        }

        public string InsertOrUpdateArtistInDb()
        {

            try
            {
                using (StreamReader sr = new StreamReader(artistFilePath))
                {
                    String line = sr.ReadToEnd();
                    JArray array = JArray.Parse(line);
                    ArtistViewModel model = new ArtistViewModel();
                    JArray colors = ColorCodes();
                    int count = 0;
                    int objAt = 0;
                    foreach (JObject obj in array)
                    {

                        try
                        {
                            model.ConvertFromJson(obj);
                        }
                        catch (Exception)
                        {
                            return "data from web service convert failed at " + objAt;
                        }

                        // for each object, look the reference id in the db
                        var entity = db.Attendees.Where(m => m.Value == model.Value).FirstOrDefault();
                        JObject color = (JObject)colors.ElementAt(count);
                        if (entity != null)
                        {
                            try
                            {
                                int id = entity.ID;
                                // if in the database, update it
                                //model.ID = entity.ID;
                                entity = model.ToArtistEntity(entity);
                                entity.Color = color["key"].ToString();
                                db.Attendees.Attach(entity);
                                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                return string.Format("Update record {0} failed", entity.Value);
                            }
                        }
                        else
                        {
                            try
                            {
                                // if not in the database, insert it
                                entity = model.ToArtistEntity(null);
                                entity.Color = color["key"].ToString();
                                db.Attendees.Add(entity);
                                db.SaveChanges();
                            }
                            catch (DbEntityValidationException dbEx)
                            {
                                foreach (var validationErrors in dbEx.EntityValidationErrors)
                                {
                                    foreach (var validationError in validationErrors.ValidationErrors)
                                    {
                                        return string.Format("Add record ref# {0} failed, because {1}.{2}", entity.Value, validationError.PropertyName, validationError.ErrorMessage);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                return string.Format("Add record ref#{0} failed, because {1}", entity.Value, e.Message);
                            }
                        }
                        objAt++;
                        count++;
                        if (count >= colors.Count)
                        {
                            count = 0;
                        }
                    }
                    recordCount = array.Count();
                }
            }
            catch (Exception e)
            {
                return "Insert or Update database fail, please contact system administrator > " + e.Message;
            }

            return "";
        }


        public void ConvertToKeyDisplayMapping()
        {

            try
            {
                artistFilePath = HttpContext.Current.Server.MapPath("~/File/Resource/") + artistFile;
                using (StreamReader sr = new StreamReader(artistFilePath))
                {
                    String line = sr.ReadToEnd();
                    JArray array = JArray.Parse(line);

                    JObject obj = (JObject)array.ElementAt(0);
                    IList<string> keys = obj.Properties().Select(p => p.Name).ToList();
                    StringBuilder sb = new StringBuilder();
                    obj = new JObject();
                    foreach (string item in keys)
                    {
                        foreach (Char c in item)
                        {
                            if (Char.IsLetterOrDigit(c))
                            {
                                sb.Append(c);
                            }
                        }
                        obj.Add(sb.ToString(), item);
                        sb.Clear();

                    }
                    string path = HttpContext.Current.Server.MapPath("~/File/Resource/") + "KeysMapping.json";
                    File.WriteAllText(path, obj.ToString());
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }

        public void ReadExcelFile()
        {
            int colNameAt = 0;
            int rowCount = 0;
            List<string> title = new List<string>();
            JsonArray arrays = new JsonArray();

            var fileName = "BYOVArtistMasterList.xlsx";
            var filePath = HttpContext.Current.Server.MapPath("~/File/Upload/") + fileName;
            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            // Want to be able to handle .xls or .xlsx file formats
            var excelReader = filePath.Contains(".xlsx")
                                  ? ExcelReaderFactory.CreateOpenXmlReader(stream)
                                  : ExcelReaderFactory.CreateBinaryReader(stream);

            excelReader.IsFirstRowAsColumnNames = true;

            excelReader.Read(); //skip first row
            while (excelReader.Read())
            {
                bool hasData = true;
                int count = 0;
                JsonObject obj = new JsonObject();
                while (hasData == true)
                {
                    string data = excelReader.GetString(count);
                    if (!string.IsNullOrEmpty(data))
                    {
                        data = data.Trim();
                        if (rowCount == colNameAt)
                        {
                            data = data.Replace("/", "");
                            data = data.Replace(" ", "_");
                            data = string.Format("{0}_{1}", data, count);
                            title.Add(data);
                        }
                        else
                        {
                            string key = title.ElementAt(count);
                            obj.Add(key, data);
                        }
                    }
                    else
                    {
                        hasData = false;
                    }
                    count++;
                }
                if ((rowCount > colNameAt) && (obj.Keys.Count() > 0))
                {
                    arrays.Add(obj);
                }
                rowCount++;
            }

            excelReader.Close();

            try
            {
                fileName = "BYOVArtistMasterList.json";
                filePath = HttpContext.Current.Server.MapPath("~/File/Download/") + fileName;

                string json = JsonConvert.SerializeObject(arrays.ToArray());

                //write string to file
                System.IO.File.WriteAllText(filePath, json);

            }
            catch (Exception)
            {

            }
        }

        public JArray ColorCodes()
        {
            try
            {
                JArray array = new JArray();
                var fileName = "colorNames.txt";
                var filePath = HttpContext.Current.Server.MapPath("~/File/Resource/") + fileName;
                string line;

                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    string[] color = line.Split(' ');
                    //string name = color[0].Trim();
                    string value = color[1].Trim();
                    JObject obj = new JObject();
                    obj.Add("key", value);
                    array.Add(obj);
                }

                file.Close();
                return array;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public void CleanMeetings()
        {
            // delete MeetingAttendees
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE MeetingAttendees");
            db.SaveChanges();
            // delete Meetings
            db.Database.ExecuteSqlCommand("DELETE FROM Meetings");
            db.SaveChanges();
        }

        public void CleanAttendees()
        {
            // delete Attendees
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Attendees");
            db.SaveChanges();
        }

        public void ExportSchedule()
        {
            try
            {
                string fileName = "schedule.xls";
                string filePath = HttpContext.Current.Server.MapPath("~/File/Download/") + fileName;

                Application xlApp;
                Workbook xlWorkBook;
                Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Application();
                xlApp.DisplayAlerts = false;

                xlWorkBook = xlApp.Workbooks.Add(misValue);

                // get the schedule start and end date
                SysSetting sysStarttDate = db.SysSettings.Where(m => m.KeyName == "StartDate").FirstOrDefault();
                SysSetting sysEndDate = db.SysSettings.Where(m => m.KeyName == "EndDate").FirstOrDefault();
                DateTime startDate = Convert.ToDateTime(sysStarttDate.Value).ToLocalTime();
                DateTime endDate = Convert.ToDateTime(sysEndDate.Value).ToLocalTime();


                // get the rooms
                List<Room> rooms = db.Rooms.OrderByDescending(m => m.Value).ToList();
                // get the attendees
                List<Attendee> listAttendees = db.Attendees.OrderBy(m => m.Value).ToList();
                // get meetings by room
                List<Meeting> meetings;
                int dayslot = 2;
                int timeslot = 1;
                startDate = Convert.ToDateTime(sysStarttDate.Value);
                foreach (Room room in rooms)
                {
                    xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.Add();
                    xlWorkSheet.Name = room.Text;
                    // set the title for each day
                    TimeSpan ts = endDate - startDate;
                    double days = ts.TotalDays;
                    xlWorkSheet.Cells[1, 1] = "Time";
                    for (int i = 1; i <= days; i++)
                    {
                        xlWorkSheet.Cells[1, i + 1] = startDate.AddDays(i-1).ToShortDateString();
                    }
                    int hour = 24 * 60;
                    int divide = 15;

                    DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    for (int i = 1; i < (hour / divide); i++)
                    {
                        xlWorkSheet.Cells[i + 1, 1] = today.AddMinutes(divide).ToShortTimeString();
                        today = today.AddMinutes(divide);
                    }

                    meetings = db.Meetings.Where(m => m.RoomID == room.Value && m.Start >= startDate).OrderBy(m => m.Start).ToList();

                
               
                    foreach (Meeting item in meetings)
                    {
                        try
                        {
                            Attendee attendee = GetAttendeeByMeeting(item, listAttendees);
                            ts = (item.Start - startDate);
                            int titleCellNo = (item.Start.Hour * 60 / divide) + item.Start.Minute / divide + timeslot;
                            int desCellNo = titleCellNo + 1;
                            int endCellNo = (item.End.Hour * 60 / divide) + item.End.Minute / divide + timeslot;
                            int theDay = (int)ts.Days + dayslot;
                            xlWorkSheet.Cells[titleCellNo, theDay] = string.Format("#{0}", attendee.Value);
                            xlWorkSheet.Cells[desCellNo, theDay] = string.Format("{0} minutes", attendee.Length);

                            Microsoft.Office.Interop.Excel.Range c1 = xlWorkSheet.Cells[titleCellNo, theDay];
                            Microsoft.Office.Interop.Excel.Range c2 = xlWorkSheet.Cells[endCellNo, theDay];

                            Microsoft.Office.Interop.Excel.Range excelRange = xlWorkSheet.get_Range(c1, c2);
                            excelRange.EntireColumn.AutoFit();
                            excelRange.Cells.Interior.Color = GetSystemColorFromHtmlCode(attendee.Color);
                        }
                        catch (Exception e)
                        {
                            string msg = e.Message;
                        }

                    }

                    // for tech departments
                    startDate = Convert.ToDateTime(sysStarttDate.Value);
                    endDate = Convert.ToDateTime(sysEndDate.Value);
                    ts = endDate - startDate;
                    for (int i = 0; i < ts.Days; i++)
                    {
                        DateTime techDateStart = startDate.AddDays(i);
                        DateTime techDateEnd = techDateStart.AddDays(1);
                        Meeting firstMeetingOfTheDay = db.Meetings.Where(m => m.Start >= techDateStart && m.Start < techDateEnd && m.RoomID == room.Value).OrderBy(m => m.Start).FirstOrDefault();
                        Meeting lastMeetingOfTheDay = db.Meetings.Where(m => m.Start >= techDateStart && m.Start < techDateEnd && m.RoomID == room.Value).OrderByDescending(m => m.Start).FirstOrDefault();
                        if (firstMeetingOfTheDay != null)
                        {
                            firstMeetingOfTheDay.End = firstMeetingOfTheDay.Start;
                            firstMeetingOfTheDay.Start = firstMeetingOfTheDay.Start.AddMinutes(-30);
                            lastMeetingOfTheDay.Start = lastMeetingOfTheDay.End;
                            lastMeetingOfTheDay.End = lastMeetingOfTheDay.End.AddMinutes(30);
                            // Tech Start
                            int titleCellNo = (firstMeetingOfTheDay.Start.Hour * 60 / divide) + firstMeetingOfTheDay.Start.Minute / divide + timeslot;
                            int endCellNo = titleCellNo+1;
                            int theDay = i + dayslot;
                            xlWorkSheet.Cells[titleCellNo, theDay] = "Tech Start";

                            Microsoft.Office.Interop.Excel.Range c1 = xlWorkSheet.Cells[titleCellNo, theDay];
                            Microsoft.Office.Interop.Excel.Range c2 = xlWorkSheet.Cells[endCellNo, theDay];
                            Microsoft.Office.Interop.Excel.Range excelRange = xlWorkSheet.get_Range(c1, c2);
                            excelRange.EntireColumn.AutoFit();
                            excelRange.Cells.Interior.Color = System.Drawing.Color.LightGreen;
                            // Tech End
                            titleCellNo = (lastMeetingOfTheDay.Start.Hour * 60 / divide) + lastMeetingOfTheDay.Start.Minute / divide + timeslot;
                            endCellNo = titleCellNo + 1;
                            xlWorkSheet.Cells[titleCellNo, theDay] = "Tech End";

                            c1 = xlWorkSheet.Cells[titleCellNo, theDay];
                            c2 = xlWorkSheet.Cells[endCellNo, theDay];
                            excelRange = xlWorkSheet.get_Range(c1, c2);
                            excelRange.EntireColumn.AutoFit();
                            excelRange.Cells.Interior.Color = System.Drawing.Color.LightGreen;
                        }

                    }
                }

                xlWorkBook.SaveAs(filePath, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
        }

        public System.Drawing.Color GetSystemColorFromHtmlCode(string htmlcolor)
        {
            return System.Drawing.ColorTranslator.FromHtml(htmlcolor);
        }

        public Attendee GetAttendeeByMeeting(Meeting meeting, List<Attendee> list)
        {
            int ID = meeting.MeetingAttendees.First().AttendeeID;
            foreach (Attendee item in list)
            {
                if (item.Value == ID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}