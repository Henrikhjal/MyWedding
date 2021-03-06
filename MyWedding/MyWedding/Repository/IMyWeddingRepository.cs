﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWedding.Models;

namespace MyWedding.Repository
{
    public interface IMyWeddingRepository
    {
        IEnumerable<Message> Messages{ get; }
        void AddMessage(MyWedding.Models.Message message);

        Message GetMessageById(int Id);
        List<Message> GetAllMessages();
        List<Message> GetAllPublicMessages();
        WishlistItem GetWishlistItemById(int wishlistId);
        List<WishlistItem> GetAllWishListItems();
        void AddWishListItem(MyWedding.Models.WishlistItem wishListItem);
        void UpdateWishListItem(MyWedding.Models.WishlistItem wishListItem);
        IEnumerable<WishlistItem> WishlistItems{ get; }
    }
}
