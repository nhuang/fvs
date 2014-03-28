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
        //
        // GET: /Attendee/
        public ActionResult Index()
        {
            return View();
        }

        private AttendeeService service;

        public AttendeeController()
		{
            this.service = new AttendeeService();
		}

        public virtual JsonResult Attendee_Read()
		{
            return Json(service.GetAll(), JsonRequestBehavior.AllowGet);
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