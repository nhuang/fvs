using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using FestivalScheduler.Models;
using FestivalScheduler.Models.Resouces;

namespace FestivalScheduler.Controllers.Scheduler
{
    public class TaskSchedulerController : Controller
    {
        private SchedulerTaskService taskService;
        private SchedulerMeetingService meetingService;

        private AttendeeService ownerService;

        //
        // GET: /TaskScheduler/
        public ActionResult Index()
        {
            return View(taskService.GetAll());
        }

     


        public TaskSchedulerController()
        {
            this.taskService = new SchedulerTaskService();
            this.meetingService = new SchedulerMeetingService();
            this.ownerService = new AttendeeService();
        }



        public virtual JsonResult Owner_Read()
        {
            return Json(ownerService.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Destroy([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            taskService.Dispose();
            meetingService.Dispose();
            ownerService.Dispose();
            base.Dispose(disposing);
        }
	}
}