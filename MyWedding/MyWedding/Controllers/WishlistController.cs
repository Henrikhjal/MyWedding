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
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly IMyWeddingRepository _MyWeddingRepository;

        public WishlistController(IMyWeddingRepository myWeddingRepository)
        {
            _MyWeddingRepository = myWeddingRepository;
        }

        // GET: Wishlist
        public ActionResult Wishlist()
        {
            string userId = "";
            if (Session["UserId"] != null)
            {
                userId = ((string)Session["UserId"].ToString()).ToLower();
            }
            userId = userId.ToLower();

            Utility.Utility.setLanguage(Request);
            Utility.Utility.WriteLog("Home-Wishlist", (string)Session["UserId"]);
            if (Session["UserId"] != null)
            {
                ViewBag.user = Session["UserId"].ToString().ToLower();
            }
            // return View(db.WishlistItems.ToList());
            return View(_MyWeddingRepository.GetAllWishListItems());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReserveUndo(int WishlistId, WishListAction WishlistAction)
        {
            if (WishlistId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WishlistItem wishlistItem = _MyWeddingRepository.GetWishlistItemById(WishlistId);  //db.WishlistItems.Find(WishlistId);

            if (wishlistItem == null)
            {
                return HttpNotFound();
            }

            if (WishlistAction == WishListAction.Reserve)
            {
                if (wishlistItem.Reserved < wishlistItem.Quantity) wishlistItem.Reserved++;
                Utility.Utility.WriteLog("Wishlist-Reserve", (string)Session["UserId"]);
            }
            else
            {
                if (wishlistItem.Reserved > 0) wishlistItem.Reserved--;
                Utility.Utility.WriteLog("Wishlist-Undo", (string)Session["UserId"]);
            }

            _MyWeddingRepository.UpdateWishListItem(wishlistItem);
            //db.Entry(wishlistItem).State = EntityState.Modified;
            //db.SaveChanges();
            Utility.Utility.setLanguage(Request);

            return PartialView("_wishListButtons", wishlistItem);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Wishlist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Details,Price,Hyperlink,Quantity,Reserved")] WishlistItem wishlistItem)
        {
            if (ModelState.IsValid)
            {
                _MyWeddingRepository.AddWishListItem(wishlistItem);
                //db.WishlistItems.Add(wishlistItem);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wishlistItem);
        }
    }
}