using System.Web.Mvc;
using MyWedding.Models;
using MyWedding.Repository;
using System.Web.Security;

namespace MyWedding.Controllers
{
    public class UserController : Controller
    {
        private readonly IMyWeddingRepository _MyWeddingRepository;

        public UserController(IMyWeddingRepository myWeddingRepository)
        {
            _MyWeddingRepository = myWeddingRepository;
        }

        public ActionResult Login()
        {
            Utility.Utility.setLanguage(Request);
            Utility.Utility.WriteLog("Users-Login (get)", "[Inloggning]");
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            double latitude = Utility.Utility.ConvertToDouble(Request.Form["Latitude"]);
            double longitude = Utility.Utility.ConvertToDouble(Request.Form["Longitude"]);
            // Request.ServerVariables
            // Request.UserHostAddress();

            if (ModelState.IsValid)
            {
                if ((user.Password.ToLower() == "lavendel" && user.UserId.ToLower() == "wedding") || (user.Password.ToLower() == "apple" && user.UserId.ToLower() == "admin") || (user.Password.ToLower() == "bmw" && user.UserId.ToLower() == "fredrik") || (user.Password.ToLower() == "trisse" && user.UserId.ToLower() == "maud") || (user.Password.ToLower() == "demo" && user.UserId.ToLower() == "demo") || (user.Password.ToLower() == "test" && user.UserId.ToLower() == "test"))
                {
                    Session["UserId"] = user.UserId;
                    FormsAuthentication.SetAuthCookie(user.UserId, false);

                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        Utility.Utility.WriteLog("Lyckad inloggning (autentiserad tidigare)", user.UserId, user.Country, user.City, latitude, longitude);
                        return RedirectToAction("Index", "Home");
                    }

                    Utility.Utility.WriteLog("Lyckad inloggning", user.UserId, user.City, user.Country, latitude, longitude);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["msg"] = "Felaktig inloggning";
                    Utility.Utility.WriteLog("Felaktig inloggning, fel pw. User: " + user.UserId + " Pw: " + user.Password, (string)user.Password, user.City, user.Country, latitude, longitude);
                    return View("Login");
                }
            }
            return View("Login");
        }

    }
}
