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
        SysSettingService service;
        public HomeController()
        {
            this.service = new SysSettingService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            SysSettingViewModel data = service.GetAbout();
            ViewBag.Content = data;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            SysSettingViewModel data = service.GetContact();
            ViewBag.Content = data;
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}