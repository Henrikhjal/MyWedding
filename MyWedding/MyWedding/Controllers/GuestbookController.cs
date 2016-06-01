using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWedding.Controllers
{
    [Authorize]
    public class GuestbookController : Controller
    {
        // GET: Guestbook
        public ActionResult Index()
        {
            Utility.Utility.setLanguage(Request);
            Utility.Utility.WriteLog("Guestbook-Index", (string)Session["UserId"]);

            return View();
        }
    }
}