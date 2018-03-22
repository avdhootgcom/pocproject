using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class PrintShopController : Controller
    {
        // GET: PrintShop
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PrintShopDashboard()
        {
            return View();
        }
        public ActionResult SearchPrintJobs()
        {
            return View();
        }
        public ActionResult LettersMailed()
        {
            return View();
        }

    }
}