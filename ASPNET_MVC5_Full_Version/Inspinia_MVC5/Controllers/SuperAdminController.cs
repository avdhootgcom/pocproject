using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class SuperAdminController : Controller
    {

        public ActionResult BroadcastMessage()
        {
            return View();
        }

        public ActionResult LookupTables()
        {
            return View();
        }

        public ActionResult ReportTemplate()
        {
            return View();
        }
        public ActionResult Permission()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult AssignRoles()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult FieldManagement()
        {
            return View();
        }
        public ActionResult RoleManagement()
        {
            return View();
        }
        public ActionResult Modules()
        {
            return View();
        }
        public ActionResult RoleAssignment()
        {
            return View();
        }
        public ActionResult SystemParameters()
        {
            return View();
        }
        public ActionResult CommunityBoardManagement()
        {
            return View();
        }
        public ActionResult FileUpload()
        {
            return View();
        }
        public ActionResult StaffDirectory()
        {
            return View();
        }
        public ActionResult Profile(string PageType="")
        {
            if (PageType == "P")
            {
                ViewBag.FieldName = "";
               
            }
            else
            {
                ViewBag.FieldName = "Home " + " / " + " Super Admin Task " + " / " + " Profile";               
            }
            return View();
        }
    }
}