using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWedding.Models;
using MyWedding.Repository;
using System.Data.Entity;

namespace MyWedding.Repository
{
    public class MyWeddingRepositoryDb : IMyWeddingRepository
    {
        private readonly MyWeddingbContext _db = new MyWeddingbContext();

        public IEnumerable<Message> Messages
        {
            get { return _db.Messages; }
        }

        public IEnumerable<WishlistItem> WishlistItems
        {
            get { return _db.WishlistItems; }
        }

        public void AddMessage(Message message)
        {
            _db.Messages.Add(message);
            _db.SaveChanges();
        }

        public void AddWishListItem(WishlistItem wishListItem)
        {
            _db.WishlistItems.Add(wishListItem);
            _db.SaveChanges();
        }

        public WishlistItem GetWishlistItemById(int wishlistId)
        {
            return _db.WishlistItems.Find(wishlistId);
        }

        public List<WishlistItem> GetAllWishListItems()
        {
            return _db.WishlistItems.ToList();
        }

        public void UpdateWishListItem(WishlistItem wishListItem)
        {
            _db.Entry(wishListItem).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public List<Message> GetAllMessages()
        {
            return _db.Messages.ToList();
        }
    }
}