using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using FestivalScheduler.Models.Resouces;


namespace FestivalScheduler.Controllers.Resources
{
    public class AttendeeController : Controller
    {
        private AttendeeService service;

        public AttendeeController()
        {
            this.service = new AttendeeService();
        }

        [Authorize(Roles = "Admin, Scheduler")]
        //
        // GET: /Attendee/
        public ActionResult Index()
        {
            return View(service.GetAllArtists());
        }


        //
        // GET: /Attendee/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Message = "";
            return View(service.GetArtistsByID(id));
        }

        //
        // POST: /Attendee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                service.Update(id, collection, ModelState);
                ViewBag.Message = "Update data succeed";
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(service.GetArtistsByID(id));
        }


        public virtual JsonResult Attendee_Read()
		{
            return Json(service.GetAll(), JsonRequestBehavior.AllowGet);
		}


        public virtual JsonResult Attendee_IndoorSelected()
        {
            return Json(service.GetAttendeesIndoorForScheduler("In"), JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult Attendee_IndoorWaiting()
        {
            return Json(service.GetAttendeesIndoorForScheduler("Waiting List"), JsonRequestBehavior.AllowGet);
        }


        public virtual JsonResult Attendee_OutdoorSelected()
        {
            return Json(service.GetAttendeesOutdoorForScheduler("In"), JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult Attendee_OutdoorWaiting()
        {
            return Json(service.GetAttendeesOutdoorForScheduler("Waiting List"), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, AttendeeViewModel rvm)
        {
            if (rvm != null && ModelState.IsValid)
            {
                service.Insert(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, AttendeeViewModel rvm)
        {
            if (rvm != null && ModelState.IsValid)
            {
                service.Update(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, AttendeeViewModel rvm)
        {
            if (rvm != null)
            {
                service.Delete(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }
	}
}