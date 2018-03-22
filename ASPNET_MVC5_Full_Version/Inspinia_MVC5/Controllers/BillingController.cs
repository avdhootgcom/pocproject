using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BillingSuspendedJobs()
        {
            return View();
        }
        public ActionResult BillingRejectedJobs()
        {
            return View();
        }
        public ActionResult BillingDashboard()
        {
            return View();
        }
        public ActionResult ListOfBillings()
        {
            return View();
        }
        public ActionResult DSNYWaitingBillingJobs()
        {
            return View();
        }
        public ActionResult JobDetails()
        {
            return View();
        }
        public ActionResult SearchBillingJob()
        {
            return View();
        }
        public ActionResult BillingReports()
        {
            return View();
        }
        public ActionResult PrintExportReports()
        {
            return View();
        }
    }
}