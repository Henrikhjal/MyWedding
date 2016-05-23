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
            Utility.Utility.setLanguage(Request);
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

        public ActionResult Info()
        {
            Utility.Utility.setLanguage(Request);
            Utility.Utility.WriteLog("Home-Info", (string)Session["UserId"]);
            return View();
        }

        public ActionResult ChangeLanguageSwe()
        {
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie == null)
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = "sv-SE";
                cookie.Expires = DateTime.Now.AddMonths(3);
                Response.Cookies.Add(cookie);
            }
            else
            {
                cookie.Value = "sv-SE";
                cookie.Expires = DateTime.Now.AddMonths(3);
                Response.SetCookie(cookie);
            }

            Utility.Utility.WriteLog("Home-ChangeLanguageSwe", (string)Session["UserId"]);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangeLanguageUK()
        {
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie == null)
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = "en-GB";
                cookie.Expires = DateTime.Now.AddMonths(3);
                Response.Cookies.Add(cookie);
            }
            else
            {
                cookie.Value = "en-GB";
                cookie.Expires = DateTime.Now.AddMonths(3);
                Response.SetCookie(cookie);
            }

            Utility.Utility.WriteLog("Home-ChangeLanguageUK", (string)Session["UserId"]);
            return RedirectToAction("Index", "Home");
        }
    }
}