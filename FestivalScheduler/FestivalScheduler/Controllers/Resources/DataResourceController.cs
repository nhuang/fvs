using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalScheduler.Models.DataResource;
using FestivalScheduler.Models.Resouces;

namespace FestivalScheduler.Controllers.Resources
{
    public class DataResourceController : Controller
    {

        private DataIOService dataIOService;
        private AttendeeService attendeeService;
         public DataResourceController()
        {
            this.dataIOService = new DataIOService();
            this.attendeeService = new AttendeeService();
        }

        //
        // GET: /DataResource/
        public ActionResult Index()
        {            
            return View();
        }

        [Authorize(Roles = "Admin, Scheduler")]
        // GET: /DataResource/GetAllArtistToExcel
        public ActionResult GetAllArtistToExcel()
        {
            try
            {
                string file = attendeeService.GetAllArtistsForExport();
                if (!file.StartsWith("Error"))
                {
                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.ClearContent();
                    response.Clear();
                    response.ContentType = "application/vnd.xls";
                    response.AddHeader("Content-Disposition", "attachment; filename=" + "ArtistMaster.csv" + ";");
                    response.TransmitFile(file);
                    response.End();
                }

            }
            catch
            {

            }
           

            return RedirectToAction("AttendeeAgenda", "Scheduler");
        }



        [Authorize(Roles = "Admin, Scheduler")]
        // GET: /DataResource/GetSchedulToExcel
        public ActionResult GetSchedulToExcel()
        {
            try
            {
                string file = dataIOService.ExportSchedule();
                if (!file.StartsWith("Error"))
                {
                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.ClearContent();
                    response.Clear();
                    response.ContentType = "application/vnd.xls";
                    response.AddHeader("Content-Disposition", "attachment; filename=" + "schedule.xls" + ";");
                    response.TransmitFile(file);
                    response.End();
                }
            }
            catch
            {

            }
            
            return RedirectToAction("AttendeeAgenda", "Scheduler");
        }

        [Authorize(Roles = "Admin, Scheduler")]
        // GET: /DataResource/ImportArtistData
        public ActionResult ImportArtistData()
        {
            return View();
        }

        // POST: /DataResource/ImportFromService
        public ActionResult ImportFromService(FormCollection collection)
        {
            try
            {
                string[] argsUser = collection.GetValues("username");
                string[] argsPassword = collection.GetValues("password");
                DataIOService dataIOService = new DataIOService();
                // import from web service and save it to a file
                ViewBag.Result =  dataIOService.ProcessImportArtistData(argsUser[0], argsPassword[0]);
            }
            catch
            {              
            }
            return View(); 
        }

        [Authorize(Roles = "Admin, Scheduler")]
        // GET: /DataResource/SchedulerResetIndex
        public ActionResult SchedulerResetIndex()
        {
            return View(); 

        }

        // POST: /DataResource/CleanMeetings
        public ActionResult CleanMeetings()
        {
            string message = "";
            try
            {
                dataIOService.CleanMeetings();          
            }
            catch(Exception e)
            {
                message = e.Message;
            }
            ViewBag.Message = message;
            return View(); 
        }

        // POST: /DataResource/CleanAttendees
        public ActionResult CleanAttendees()
        {
            string message = "";
            try
            {
                dataIOService.CleanAttendees();
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            ViewBag.Message = message;
            return View(); 
        }
	}
}