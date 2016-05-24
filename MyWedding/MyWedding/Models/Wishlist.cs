using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MyWedding.Resources;

namespace MyWedding.Models
{
    public enum WishListAction
    {
        Reserve = 1,
        Undo = 2
    }

    public class WishlistItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Max 30 tecken")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Max 200 tecken")]
        public string Details { get; set; }
        public Nullable<int> Price { get; set; }

        [StringLength(300, ErrorMessage = "Max 300 tecken")]
        [Display(Name = "Länk")]
        [Url(ErrorMessage = "Ange en giltig URL, t.ex. http://www.dn.se")]
        public string Hyperlink { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int Reserved { get; set; }
    }
}
