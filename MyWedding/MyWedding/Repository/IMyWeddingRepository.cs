using System;
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
        WishlistItem FindWishlistItemById(int wishlistId);
        List<WishlistItem> GetAllWishListItems();
        void AddWishListItem(MyWedding.Models.WishlistItem wishListItem);
    }
}
