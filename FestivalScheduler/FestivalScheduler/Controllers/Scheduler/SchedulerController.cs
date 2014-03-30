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
    public class SchedulerController : Controller
    {
        //
        // GET: /Scheduler/
        public ActionResult Index()
        {
            return View(roomService.GetAll());
        }
         private SchedulerTaskService taskService;
        private SchedulerMeetingService meetingService;
        private AttendeeService attendeeService;
        private RoomService roomService;
        public SchedulerController()
        {
            this.taskService = new SchedulerTaskService();
            this.meetingService = new SchedulerMeetingService();
            this.attendeeService = new AttendeeService();
            this.roomService = new RoomService();
        }


        // GET: /Scheduler/Mix
        public ActionResult Mix()
        {
            return View(roomService.GetAll());
        }

        // GET: /Scheduler/Attendee
        public ActionResult Attendee()
        {
              return View(attendeeService.GetAll());
        }
 
        // GET: /Scheduler/Horizontal
        public ActionResult Horizontal()
        {
            return View(roomService.GetAll());
        }

        // GET: /Scheduler/Vertical
        public ActionResult Vertical()
        {
            return View(roomService.GetAll());
        }

        // GET: /Scheduler/AttendeeAgenda
        public ActionResult AttendeeAgenda(){

            return View(meetingService.GetAllMeetingAgenda());
        }

        // GET: /Scheduler/ResetMeetingTitles
        public ActionResult ResetMeetingTitles()
        {
            meetingService.ResetAllMeetingTitle();
            return RedirectToAction("AttendeeAgenda", "Scheduler");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HRoomFilter(FormCollection collection)
        {
            string[] periods = collection.GetValues("timeStart");
            int timeStartHour =Convert.ToInt32(periods[0].Substring(0, periods[0].IndexOf(':')));
            int timeStartMin = Convert.ToInt32(periods[0].Substring(periods[0].IndexOf(':')+1,2).Trim());
            ViewBag.timeStart = new DateTime(DateTime.Now.Year, 1, 1, timeStartHour, timeStartMin, 0);
            periods = collection.GetValues("timeEnd");
            int timeEndHour = Convert.ToInt32(periods[0].Substring(0, periods[0].IndexOf(':')));
            int timeEndMin = Convert.ToInt32(periods[0].Substring(periods[0].IndexOf(':') + 1, 2).Trim());
            ViewBag.timeEnd = new DateTime(DateTime.Now.Year, 1, 1, timeEndHour, timeEndMin, 0);

            
            string[] strs = collection.GetValues("room");
            roomService.UpdateRoomsToShow(strs);
            return View(roomService.GetAll());
        }

           [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HAttendeeFilter(FormCollection collection)
        {
            string[] strs = collection.GetValues("attendee");
            attendeeService.UpdateAttendeesToShow(strs);
            return View(attendeeService.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VRoomFilter(FormCollection collection)
        {
            string[] strs = collection.GetValues("room");
            roomService.UpdateRoomsToShow(strs);
            return View(roomService.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MixFilter(FormCollection collection)
        {
            string[] strs = collection.GetValues("room");
            roomService.UpdateRoomsToShow(strs);
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