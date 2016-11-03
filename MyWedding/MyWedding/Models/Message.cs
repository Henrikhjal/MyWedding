using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWedding.Resources;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyWedding.Models
{
    [DataContract]
    public class Message
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Display(Name = "name", ResourceType = typeof(Wedding))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "namemandatory", ErrorMessageResourceType = typeof(Wedding))]

        public string Name { get; set; }

        [DataMember]
        [Display(Name = "message", ResourceType = typeof(Wedding))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "messagemandatory", ErrorMessageResourceType = typeof(Wedding))]

        public string MessageText { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public bool Public { get; set; }
    }
}