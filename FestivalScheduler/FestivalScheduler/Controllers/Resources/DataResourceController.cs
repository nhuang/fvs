using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalScheduler.Models.DataResource;

namespace FestivalScheduler.Controllers.Resources
{
    public class DataResourceController : Controller
    {
        //
        // GET: /DataResource/
        public ActionResult Index()
        {
            DataIOService dataIOService = new DataIOService();
            dataIOService.ReadFile();
            return View();
        }
	}
}