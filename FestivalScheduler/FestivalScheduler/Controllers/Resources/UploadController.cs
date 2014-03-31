using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalScheduler.Controllers.Resources
{
    public class UploadController : Controller
    {
        List<string> uploadFileNames = new List<string>();

        //
        // GET: /Upload/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                var filePath = Server.MapPath("/Images/");
                uploadFileNames = new List<string>();

                foreach (HttpPostedFileBase file in files)
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    string savedFileName = Path.Combine(filePath, fileName);
                    file.SaveAs(savedFileName);
                    uploadFileNames.Add(string.Format("{0} succeed.\n", fileName));
                }

            }
            ViewBag.Message = uploadFileNames;
            return View();
        }
    }
}