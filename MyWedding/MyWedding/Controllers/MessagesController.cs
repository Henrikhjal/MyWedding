using System;
using System.Web.Mvc;
using MyWedding.Models;
using MyWedding.Repository;
using System.Collections.Generic;

namespace MyWedding.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IMyWeddingRepository _MyWeddingRepository;

        public MessagesController(IMyWeddingRepository  myWeddingRepository)
        {
            _MyWeddingRepository = myWeddingRepository;
        }

        public ActionResult Contacts()
        {
            Utility.Utility.setLanguage(Request);
            Utility.Utility.WriteLog("Home-Contacts", (string)Session["UserId"]);
            return View();
        }

        public ViewResult ShowMessages()
        {
            List<Message> msg = _MyWeddingRepository.GetAllMessages();

            //return View(_MyWeddingRepository.GetAllMessages());
            return View(_MyWeddingRepository.Messages);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMessage([Bind(Include = "Id, Name, MessageText")] Message message)
        {
            if (ModelState.IsValid)
            {
                message.Date = DateTime.Now;
                message.Public = false;
                _MyWeddingRepository.AddMessage(message);
                Utility.Utility.WriteLog("Home-Messages-Create", (string)Session["UserId"]);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}