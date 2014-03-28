using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using FestivalScheduler;
using FestivalScheduler.Models;
using FestivalScheduler.Models.Resouces;

namespace FestivalScheduler.Controllers.Scheduler
{
    public class HSchedulerController : Controller
    {

        private SchedulerTaskService taskService;
        private SchedulerMeetingService meetingService;
        private AttendeeService attendeeService;
        private fschedulerEntities db;
        public HSchedulerController()
        {
            this.taskService = new SchedulerTaskService();
            this.meetingService = new SchedulerMeetingService();
            this.attendeeService = new AttendeeService();
            this.db = new fschedulerEntities();
        }

        //
        // GET: /HScheduler/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /HScheduler/Mix
        public ActionResult Mix()
        {
            return View();
        }

        // GET: /HScheduler/Attendee
        public ActionResult Attendee()
        {
              return View();
        }

        // GET: /HScheduler/Vertical
        public ActionResult Vertical()
        {
            return View();
        }

        public virtual JsonResult Grouping_Horizontal_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(meetingService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Grouping_Horizontal_Destroy([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Delete(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Grouping_Horizontal_Create([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Insert(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Grouping_Horizontal_Update([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Update(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }
	}
}