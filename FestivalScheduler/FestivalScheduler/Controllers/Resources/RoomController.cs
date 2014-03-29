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
			return View(roomService.GetAll());
		}


		public virtual JsonResult Room_Read()
		{
			return Json(roomService.GetAll(), JsonRequestBehavior.AllowGet);
		}

        public virtual JsonResult Room_Selected()
        {
            return Json(roomService.GetRoomsForScheduler(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(roomService.GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, RoomViewModel rvm)
        {
            if (rvm != null && ModelState.IsValid)
            {
                roomService.Insert(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, RoomViewModel rvm)
        {
            if (rvm != null && ModelState.IsValid)
            {
                roomService.Update(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, RoomViewModel rvm)
        {
            if (rvm != null)
            {
                roomService.Delete(rvm, ModelState);
            }

            return Json(new[] { rvm }.ToDataSourceResult(request, ModelState));
        }

	}
}