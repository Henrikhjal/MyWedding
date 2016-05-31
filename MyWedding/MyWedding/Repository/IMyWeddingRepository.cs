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
        

        void AddMessage(MyWedding.Models.Message message);
        WishlistItem GetWishlistItemById(int wishlistId);
        List<WishlistItem> GetAllWishListItems();
        void AddWishListItem(MyWedding.Models.WishlistItem wishListItem);
        void UpdateWishListItem(MyWedding.Models.WishlistItem wishListItem);
    }
}
