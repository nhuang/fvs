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
    public class SysSettingController : Controller
    {
        private SysSettingService settingService;

        public SysSettingController()
        {
            this.settingService = new SysSettingService();
        }

        //
        // GET: /SysSetting/
        public ActionResult Index()
        {
            return View(settingService.GetAll());
        }

        public ActionResult ImageBrowser()
        {
            return View();
        }
        //
        // GET: /SysSetting/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SysSetting/Create
        public ActionResult Create()
        {
            ViewBag.UrlAddress = this.Request.Url.Host;
            return View();
        }

        //
        // POST: /SysSetting/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ViewBag.UrlAddress = this.Request.Url.Host;
                SysSettingViewModel sys = ConvertToViewModel(collection);

                settingService.Insert(sys, ModelState);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SysSetting/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.UrlAddress = this.Request.Url.Host;
            return View(settingService.GetById(id));
        }

        //
        // POST: /SysSetting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ViewBag.UrlAddress = this.Request.Url.Host;
                SysSettingViewModel sys = ConvertToViewModel(collection);
                sys.ID = id;
                settingService.Update(sys, ModelState);
                return RedirectToAction("Index");
            }
            catch
            {
               return View(settingService.GetById(id));
            }
        }

        //
        // GET: /SysSetting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SysSetting/Delete/5
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

        private SysSettingViewModel ConvertToViewModel(FormCollection collection)
        {
            SysSettingViewModel model = new SysSettingViewModel();
            model.KeyName = Convert.ToString(collection.GetValues("KeyName")[0]);
            model.ValueType = Convert.ToString(collection.GetValues("ValueType")[0]);
            model.Value = Convert.ToString(collection.GetValues("Value")[0]);
            model.KeyGroup = Convert.ToString(collection.GetValues("KeyGroup")[0]);
            model.Description = HttpUtility.HtmlDecode(collection.GetValues("Description")[0]);
            return model;
        }
    }
}
