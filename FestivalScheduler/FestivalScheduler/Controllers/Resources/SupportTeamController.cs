using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using FestivalScheduler.Models.Resouces;
using FestivalScheduler.Models;

namespace FestivalScheduler.Controllers.Resources
{
    public class SupportTeamController : Controller
    {
        private SupportTeamService service;
        private SchedulerMeetingService meetingService;
        private AttendeeService attendeeService;

        public SupportTeamController()
        {
            this.service = new SupportTeamService();
            this.meetingService = new SchedulerMeetingService();
            this.attendeeService = new AttendeeService();
        }

        //
        // GET: /SupportTeam/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /SupportTeam/Assignment
        public ActionResult Assignment()
        {
            ViewBag.Attendees = attendeeService.GetAll();
            ViewBag.SupportTeams = service.GetAll();

            return View();
        }
     

           //
        // POST: /SupportTeam/Assignment
        [HttpPost]
        public ActionResult Assignment(FormCollection collection)
        {
            string[] assignments = collection.GetValues("assignment");
            foreach (string item in assignments)
            {
                string str = item;
            }
            ViewBag.Attendees = attendeeService.GetAll();
            ViewBag.SupportTeams = service.GetAll();

            return View();
        }


        public virtual JsonResult Read()
		{
            return Json(service.GetAll(), JsonRequestBehavior.AllowGet);
		}

        

        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, SupportTeamViewModel rvm)
        {
            if (rvm != null && ModelState.IsValid)
            {
                service.Insert(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, SupportTeamViewModel rvm)
        {
            if (rvm != null && ModelState.IsValid)
            {
                service.Update(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, SupportTeamViewModel rvm)
        {
            if (rvm != null)
            {
                service.Delete(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

	}
}