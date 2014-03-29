using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MvcCheckBoxList.Model;

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
        private RoomService roomService;
        public HSchedulerController()
        {
            this.taskService = new SchedulerTaskService();
            this.meetingService = new SchedulerMeetingService();
            this.attendeeService = new AttendeeService();
            this.roomService = new RoomService();
        }

        //
        // GET: /HScheduler/
        public ActionResult Index()
        {
            return View(roomService.GetAll());
        }

        // GET: /HScheduler/Mix
        public ActionResult Mix()
        {
            return View(roomService.GetAll());
        }

        // GET: /HScheduler/Attendee
        public ActionResult Attendee()
        {
              return View();
        }

        // GET: /HScheduler/Vertical
        public ActionResult Vertical()
        {
            return View(roomService.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HRoomFilter(FormCollection collection)
        {
            string[] strs = collection.GetValues("room");
            roomService.UpdateRoomToShow(strs);
            return View(roomService.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VRoomFilter(FormCollection collection)
        {
            string[] strs = collection.GetValues("room");
            roomService.UpdateRoomToShow(strs);
            return View(roomService.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MixFilter(FormCollection collection)
        {
            string[] strs = collection.GetValues("room");
            roomService.UpdateRoomToShow(strs);
            return View(roomService.GetAll());
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