using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWedding.Models;
using MyWedding.Repository;
using System.Net;

namespace MyWedding.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IMyWeddingRepository _MyWeddingRepository;

        public WishlistController(IMyWeddingRepository myWeddingRepository)
        {
            _MyWeddingRepository = myWeddingRepository;
        }

        // GET: Wishlist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReserveUndo(int WishlistId, int WishlistAction)
        {
            if (WishlistId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WishlistItem wishlistItem = _MyWeddingRepository.FindWishlistItemById(WishlistId);

            if (wishlistItem == null)
            {
                return HttpNotFound();
            }

            if (WishlistAction == 1)
            {
                if (wishlistItem.Reserved < wishlistItem.Quantity) wishlistItem.Reserved++;
                Utility.Utility.WriteLog("Wishlist-Reserve", (string)Session["UserId"]);
            }
            else
            {
                if (wishlistItem.Reserved > 0) wishlistItem.Reserved--;
                Utility.Utility.WriteLog("Wishlist-Undo", (string)Session["UserId"]);
            }

            db.Entry(wishlistItem).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Wishlist");
            //return View(db.WishlistItems.ToList());
        }

    }
}