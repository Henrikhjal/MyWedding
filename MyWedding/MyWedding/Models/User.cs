using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyWedding.Resources;

namespace MyWedding.Models
{
    public class User
    {
        // public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "namemandatory", ErrorMessageResourceType = typeof(Wedding))]
        // [Display(Name = "Name")]
        [Display(Name = "name", ResourceType = typeof(Wedding))]
        public string UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "pwmandatory", ErrorMessageResourceType = typeof(Wedding))]
        [DataType(DataType.Password)]
        [Display(Name = "password", ResourceType = typeof(Wedding))]
        public string Password { get; set; }

        public string Latitue { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

}