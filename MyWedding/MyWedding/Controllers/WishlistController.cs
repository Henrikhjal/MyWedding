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

            //hh db.Entry(wishlistItem).State = EntityState.Modified;
            //hh db.SaveChanges();
            return RedirectToAction("Wishlist");
            //return View(db.WishlistItems.ToList());
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