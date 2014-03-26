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
    public class RoomController : Controller
    {
        private RoomService roomService;

        public RoomController()
        {
            this.roomService = new RoomService();
        }

        //
        // GET: /Room/
        public ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult Room_Read()
        {
            return Json(roomService.GetAll(), JsonRequestBehavior.AllowGet);
        }

	}
}