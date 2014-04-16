using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using RestSharp;
using System.Net;
using System.Text;
using FestivalScheduler.Models.Resouces;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace FestivalScheduler.Models.DataResource
{
    public class DataIOService
    {

        private fschedulerEntities db;
        private string artistFile = "ArtistData.json";
        private string artistFilePath = "";

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
                    return string.Format("Processed {0} records success.", array.Count);
                }
            }
            catch (Exception e)
            {
                return "Insert or Update database fail, please contact system administrator > " + e.Message;
            }
            return "";
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
    }
}