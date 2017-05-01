using briggs50_Reviewer.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace briggs50_Reviewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Your admin page.";

            return View();
        }
    }
}