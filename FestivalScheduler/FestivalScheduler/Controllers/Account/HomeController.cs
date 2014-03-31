using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalScheduler.Models.Resouces;

namespace AspNetGroupBasedPermissions.Controllers
{
    public class HomeController : Controller
    {
        SysSettingService settingService;
        SysEventService eventService;
        public HomeController()
        {
            this.settingService = new SysSettingService();
            this.eventService = new SysEventService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            SysSettingViewModel data = settingService.GetAbout();
            ViewBag.Content = data;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            SysSettingViewModel data = settingService.GetContact();
            ViewBag.Content = data;
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Events()
        {
            return View(eventService.GetTodayEvents());
        }
    }
}