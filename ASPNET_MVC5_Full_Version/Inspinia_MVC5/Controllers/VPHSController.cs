using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class VPHSController : Controller
    {

        public ActionResult InspectorDashboard()
        {
            return View();
        }
        public ActionResult SupervisorDashboard()
        {
            return View();
        }
    }
}