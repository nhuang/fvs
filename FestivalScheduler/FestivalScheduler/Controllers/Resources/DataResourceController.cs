﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalScheduler.Models.DataResource;

namespace FestivalScheduler.Controllers.Resources
{
    public class DataResourceController : Controller
    {

        private DataIOService dataIOService;

         public DataResourceController()
        {
            this.dataIOService = new DataIOService();
        }

        //
        // GET: /DataResource/
        public ActionResult Index()
        {            
            return View();
        }

        // GET: /DataResource/ImportArtistData
        public ActionResult ImportArtistData()
        {
            return View();
        }

        // POST: /DataResource/ImportFromService
        public ActionResult ImportFromService(FormCollection collection)
        {
            try
            {
                string[] argsUser = collection.GetValues("username");
                string[] argsPassword = collection.GetValues("password");
                DataIOService dataIOService = new DataIOService();
                // import from web service and save it to a file
                ViewBag.Result =  dataIOService.ProcessImportArtistData(argsUser[0], argsPassword[0]);
            }
            catch
            {              
            }
            return View(); 
        }

        // GET: /DataResource/SchedulerResetIndex
        public ActionResult SchedulerResetIndex()
        {
            return View(); 

        }

        // POST: /DataResource/CleanMeetings
        public ActionResult CleanMeetings()
        {
            string message = "";
            try
            {
                dataIOService.CleanMeetings();          
            }
            catch(Exception e)
            {
                message = e.Message;
            }
            ViewBag.Message = message;
            return View(); 
        }

        // POST: /DataResource/CleanAttendees
        public ActionResult CleanAttendees()
        {
            string message = "";
            try
            {
                dataIOService.CleanAttendees();
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            ViewBag.Message = message;
            return View(); 
        }
	}
}