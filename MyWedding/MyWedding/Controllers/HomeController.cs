using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWedding.Utility;

namespace MyWedding.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TechnicalInfo()
        {
            Utility.Utility.setLanguage(Request);
            //Utility.Utility.WriteLog("Home-TechnicalInfo", (string)Session["UserId"]);
            return View();
        }

        public ActionResult Program()
        {
            Utility.Utility.setLanguage(Request);
            Utility.Utility.WriteLog("Home-Program", (string)Session["UserId"]);
            return View();
        }

        public ActionResult Contacts()
        {
            Utility.Utility.setLanguage(Request);
            Utility.Utility.WriteLog("Home-Contacts", (string)Session["UserId"]);
            return View();
        }
    }
}