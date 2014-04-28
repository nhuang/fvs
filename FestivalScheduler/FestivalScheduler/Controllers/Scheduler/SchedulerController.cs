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
using FestivalScheduler.Models.DataResource;

namespace FestivalScheduler.Controllers.Scheduler
{
    public class SchedulerController : Controller
    {

        private SchedulerTaskService taskService;
        private SchedulerMeetingService meetingService;
        private AttendeeService attendeeService;
        private RoomService roomService;
        private SysEventService eventService;
        private SysSettingService settingService;
        private string datePatten = "MMM-dd-yyyy";
        private string timePatten = "hh:mm tt";

        public SchedulerController()
        {
            this.taskService = new SchedulerTaskService();
            this.meetingService = new SchedulerMeetingService();
            this.attendeeService = new AttendeeService();
            this.roomService = new RoomService();
            this.eventService = new SysEventService();
            this.settingService = new SysSettingService();
        }

        //
        // GET: /Scheduler/
        public ActionResult Index()
        {
            ViewBag.StartHour = settingService.GetStartHour();
            ViewBag.StartMinute = settingService.GetStartMinute();
            ViewBag.EndHour = settingService.GetEndHour();
            ViewBag.EndMinute = settingService.GetEndMinute();
            ViewBag.StartDate = settingService.GetStartDate();
            ViewBag.EndDate = settingService.GetGetEndDate();

            return View(roomService.GetAll());
        }


        // GET: /Scheduler/Attendee
        public ActionResult Attendee()
        {
            ViewBag.StartHour = settingService.GetStartHour();
            ViewBag.StartMinute = settingService.GetStartMinute();
            ViewBag.EndHour = settingService.GetEndHour();
            ViewBag.EndMinute = settingService.GetEndMinute();
            ViewBag.StartDate = settingService.GetStartDate();
            ViewBag.EndDate = settingService.GetGetEndDate();

            return View(attendeeService.GetAll());
        }

        // GET: /Scheduler/Horizontal
        public ActionResult Horizontal()
        {
            ViewBag.StartHour = settingService.GetStartHour();
            ViewBag.StartMinute = settingService.GetStartMinute();
            ViewBag.EndHour = settingService.GetEndHour();
            ViewBag.EndMinute = settingService.GetEndMinute();
            ViewBag.StartDate = settingService.GetStartDate();
            ViewBag.EndDate = settingService.GetGetEndDate();
            return View(roomService.GetRoomsByType("Indoor"));
        }
        // GET: /Scheduler/OutdoorHorizontal
        public ActionResult OutdoorHorizontal()
        {
            ViewBag.StartHour = settingService.GetStartHour();
            ViewBag.StartMinute = settingService.GetStartMinute();
            ViewBag.EndHour = settingService.GetEndHour();
            ViewBag.EndMinute = settingService.GetEndMinute();
            ViewBag.StartDate = settingService.GetStartDate();
            ViewBag.EndDate = settingService.GetGetEndDate();
            return View(roomService.GetRoomsByType("Outdoor"));
        }

        // GET: /Scheduler/Vertical
        public ActionResult Vertical()
        {
            ViewBag.StartHour = settingService.GetStartHour();
            ViewBag.StartMinute = settingService.GetStartMinute();
            ViewBag.EndHour = settingService.GetEndHour();
            ViewBag.EndMinute = settingService.GetEndMinute();
            ViewBag.StartDate = settingService.GetStartDate();
            ViewBag.EndDate = settingService.GetGetEndDate();

            return View(roomService.GetRoomsByType("Indoor"));
        }

        // GET: /Scheduler/OutdoorVertical
        public ActionResult OutdoorVertical()
        {
            ViewBag.StartHour = settingService.GetStartHour();
            ViewBag.StartMinute = settingService.GetStartMinute();
            ViewBag.EndHour = settingService.GetEndHour();
            ViewBag.EndMinute = settingService.GetEndMinute();
            ViewBag.StartDate = settingService.GetStartDate();
            ViewBag.EndDate = settingService.GetGetEndDate();

            return View(roomService.GetRoomsByType("Outdoor"));
        }

        // GET: /Scheduler/AttendeeAgenda
        public ActionResult AttendeeAgenda()
        {
            return View(attendeeService.CountShowsForAttendee());
        }

        // GET: /Scheduler/TimeTable
        public ActionResult TimeTable()
        {
            return View(meetingService.GetAllMeetingAgenda());
            
        }

        // GET: /Scheduler/AttendeeShows
        public ActionResult AttendeeShows()
        {
            return View(attendeeService.CountShowsForAttendee());
        }

        // GET: /Scheduler/ResetMeetingTitles
        public ActionResult ResetMeetingTitles()
        {
            meetingService.ResetAllMeetingTitle();
            return RedirectToAction("AttendeeAgenda", "Scheduler");
        }


        // GET: /Scheduler/GenerateAgendaPDF
        public ActionResult GenerateAgendaPDF()
        {
            PDFService pdf = new PDFService();
            pdf.GenerateAgendaPDF();

            return RedirectToAction("AttendeeAgenda", "Scheduler");
        }

        // GET: /Scheduler/ReplaceMeetingByReferenceID
        public ActionResult ReplaceMeetingByReferenceID()
        {
            return View();
        }

        // GET: /Scheduler/ReplaceOutdoorMeetingByReferenceID
        public ActionResult ReplaceOutdoorMeetingByReferenceID()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProcessMeetingByReferenceID(FormCollection collection)
        {
            string[] fromID = collection.GetValues("From");
            string[] toID = collection.GetValues("To");
            string[] startDate = collection.GetValues("datetimepicker");

            ViewBag.Result =  meetingService.ReplaceMeetingByReferenceID(fromID[0], toID[0], startDate[0], this.ModelState);
            attendeeService.ReplaceAttendeeStatus(fromID[0], toID[0]);

            NewSysEvent(SysEventViewModel.NEW, string.Format("Meeting Ref#{0} replaced by Ref#{1}, start from {2}.", fromID[0], toID[0], startDate[0]));
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HRoomFilter(FormCollection collection)
        {
            string[] periods = collection.GetValues("timeStart");
            int timeStartHour = Convert.ToInt32(periods[0].Substring(0, periods[0].IndexOf(':')));
            int timeStartMin = Convert.ToInt32(periods[0].Substring(periods[0].IndexOf(':') + 1, 2).Trim());
            ViewBag.timeStart = new DateTime(DateTime.Now.Year, 1, 1, timeStartHour, timeStartMin, 0);
            periods = collection.GetValues("timeEnd");
            int timeEndHour = Convert.ToInt32(periods[0].Substring(0, periods[0].IndexOf(':')));
            int timeEndMin = Convert.ToInt32(periods[0].Substring(periods[0].IndexOf(':') + 1, 2).Trim());
            ViewBag.timeEnd = new DateTime(DateTime.Now.Year, 1, 1, timeEndHour, timeEndMin, 0);
            ViewBag.StartDate = settingService.GetStartDate();

            string[] strs = collection.GetValues("room");
            roomService.UpdateRoomsToShow(strs);
            return View(roomService.GetRoomsByType("Indoor"));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HAttendeeFilter(FormCollection collection)
        {
            string[] periods = collection.GetValues("timeStart");
            int timeStartHour = Convert.ToInt32(periods[0].Substring(0, periods[0].IndexOf(':')));
            int timeStartMin = Convert.ToInt32(periods[0].Substring(periods[0].IndexOf(':') + 1, 2).Trim());
            ViewBag.timeStart = new DateTime(DateTime.Now.Year, 1, 1, timeStartHour, timeStartMin, 0);
            periods = collection.GetValues("timeEnd");
            int timeEndHour = Convert.ToInt32(periods[0].Substring(0, periods[0].IndexOf(':')));
            int timeEndMin = Convert.ToInt32(periods[0].Substring(periods[0].IndexOf(':') + 1, 2).Trim());
            ViewBag.timeEnd = new DateTime(DateTime.Now.Year, 1, 1, timeEndHour, timeEndMin, 0);
            ViewBag.StartDate = settingService.GetStartDate();

            string[] strs = collection.GetValues("attendee");
            attendeeService.UpdateAttendeesToShow(strs);
            return View(attendeeService.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VRoomFilter(FormCollection collection)
        {
            ViewBag.StartHour = settingService.GetStartHour();
            ViewBag.StartMinute = settingService.GetStartMinute();
            ViewBag.EndHour = settingService.GetEndHour();
            ViewBag.EndMinute = settingService.GetEndMinute();
            ViewBag.StartDate = settingService.GetStartDate();
            ViewBag.EndDate = settingService.GetGetEndDate();


            string[] strs = collection.GetValues("Venue");
            roomService.UpdateRoomsToShow(strs);
            return View(roomService.GetRoomsByType("Indoor"));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VOutdoorRoomFilter(FormCollection collection)
        {
            ViewBag.StartHour = settingService.GetStartHour();
            ViewBag.StartMinute = settingService.GetStartMinute();
            ViewBag.EndHour = settingService.GetEndHour();
            ViewBag.EndMinute = settingService.GetEndMinute();
            ViewBag.StartDate = settingService.GetStartDate();
            ViewBag.EndDate = settingService.GetGetEndDate();


            string[] strs = collection.GetValues("Venue");
            roomService.UpdateRoomsToShow(strs);
            return View(roomService.GetRoomsByType("Outdoor"));
        }

        public virtual JsonResult Indoor_Horizontal_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(meetingService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Indoor_Horizontal_Destroy([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Delete(meeting, ModelState);
                NewSysEvent(SysEventViewModel.DELETED, string.Format("Indoor Meeting {0} deleted. Schedule : {1} {2} to {3}. {4}", meeting.Title, meeting.Start.ToString(datePatten), meeting.Start.ToString(timePatten), meeting.End.ToString(timePatten), meeting.Description));
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Indoor_Horizontal_Create([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Insert(meeting, ModelState);
                NewSysEvent(SysEventViewModel.NEW, string.Format("Indoor Meeting {0} created. Schedule: {1} {2} to {3}. {4}", meeting.Title, meeting.Start.ToString(datePatten), meeting.Start.ToString(timePatten), meeting.End.ToString(timePatten), meeting.Description));
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Indoor_Horizontal_Update([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Update(meeting, ModelState);
                NewSysEvent(SysEventViewModel.UPDATE, string.Format("Indoor Meeting {0} updated. Schedule: {1} {2} to {3}. {4}", meeting.Title, meeting.Start.ToString(datePatten), meeting.Start.ToString(timePatten), meeting.End.ToString(timePatten), meeting.Description));
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        private void NewSysEvent(string level, string message)
        {

            SysEventViewModel newEvent = new SysEventViewModel().Init(level, message, "System");
            eventService.Insert(newEvent, ModelState);
        }

    }
}