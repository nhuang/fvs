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
    public class SysEventController : Controller
    {
        private SysEventService eventService;

        public SysEventController()
        {
            this.eventService = new SysEventService();
        }

        //
        // GET: /SysEvent/
        public ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(eventService.GetAll().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, SysEventViewModel rvm)
        {
            if (rvm != null && ModelState.IsValid)
            {
                eventService.Insert(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, SysEventViewModel rvm)
        {
            if (rvm != null && ModelState.IsValid)
            {
                eventService.Update(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual JsonResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, SysEventViewModel evm)
        {
            if (ModelState.IsValid)
            {
                eventService.Delete(evm, ModelState);
            }

            return Json(new[] { evm }.ToDataSourceResult(request, ModelState));
        }
        //
        // GET: /SysEvent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SysEvent/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SysEvent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                SysEventViewModel newEvent = ConvertToViewModel(collection);
                eventService.Insert(newEvent, ModelState);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /SysEvent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SysEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SysEvent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SysEvent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private SysEventViewModel ConvertToViewModel(FormCollection collection)
        {
            SysEventViewModel model = new SysEventViewModel();
            model.Level = Convert.ToString(collection.GetValues("Level")[0]);
            model.Message = Convert.ToString(collection.GetValues("Message")[0]);
            model.UpdateAt = DateTime.Now;
            model.CreateBy = "System";
            return model;
        }
    }
}
