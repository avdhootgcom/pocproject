using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class PropertyResearchController : Controller
    {
        // GET: PropertyResearch
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult AddressReview()
        {
            return View();
        }
        public ActionResult ListOfQueues()
        {
            return View(); 
        }
        public ActionResult ResearchAssignmentQueue()
        {
            return View();
        }
        public ActionResult MyResearchQueue()
        {
            return View();
        }
        public ActionResult JobDetails()
        {
            return View();
        }
        public ActionResult PropertyResearchDashboard()
        {
            return View();
        }
        public ActionResult GeneralizedSearch()
        {
            return View();
        }
        public ActionResult ProductivityDashboard()
        {
            return View();
        }
        public ActionResult OwnerUpdates()
        {
            return View();
        }
    }
}