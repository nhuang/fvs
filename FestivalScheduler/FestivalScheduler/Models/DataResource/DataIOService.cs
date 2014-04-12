using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel;
using System.IO;
using Newtonsoft.Json;
using ComputerBeacon.Json;

namespace FestivalScheduler.Models.DataResource
{
    public class DataIOService
    {
        public void ReadFile()
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
                            data = data.Replace("/","");
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
                if(rowCount>colNameAt){
                    arrays.Add(obj);
                }
                rowCount++;
            }

            excelReader.Close();
        }
    }
}