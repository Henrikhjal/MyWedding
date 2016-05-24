using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWedding.Resources;
using System.ComponentModel.DataAnnotations;

namespace MyWedding.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "name", ResourceType = typeof(Wedding))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "namemandatory", ErrorMessageResourceType = typeof(Wedding))]

        public string Name { get; set; }

        [Display(Name = "message", ResourceType = typeof(Wedding))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "messagemandatory", ErrorMessageResourceType = typeof(Wedding))]

        public string MessageText { get; set; }

        public DateTime Date { get; set; }

        public bool Public { get; set; }
    }
}