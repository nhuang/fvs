﻿using System;
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
            return View(roomService.GetAll());
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

            return View(roomService.GetAll());
        }

        // GET: /Scheduler/AttendeeAgenda
        public ActionResult AttendeeAgenda()
        {
            ViewBag.Shows = attendeeService.CountShowsForAttendee();
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
            return View(roomService.GetAll());
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
                NewSysEvent(SysEventViewModel.DELETED, string.Format("Meeting {0} deleted. Schedule : {1} {2} to {3}. {4}", meeting.Title, meeting.Start.ToString(datePatten),meeting.Start.ToString(timePatten),meeting.End.ToString(timePatten),meeting.Description));
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Grouping_Horizontal_Create([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Insert(meeting, ModelState);
                NewSysEvent(SysEventViewModel.NEW, string.Format("Meeting {0} created. Schedule: {1} {2} to {3}. {4}", meeting.Title, meeting.Start.ToString(datePatten), meeting.Start.ToString(timePatten), meeting.End.ToString(timePatten), meeting.Description));
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Grouping_Horizontal_Update([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Update(meeting, ModelState);
                NewSysEvent(SysEventViewModel.UPDATE, string.Format("Meeting {0} updated. Schedule: {1} {2} to {3}. {4}", meeting.Title, meeting.Start.ToString(datePatten), meeting.Start.ToString(timePatten), meeting.End.ToString(timePatten), meeting.Description));
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