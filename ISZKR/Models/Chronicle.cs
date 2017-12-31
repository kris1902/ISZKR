using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISZKR.Models
{
    public class Chronicle
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public bool IsPublic { get; set; }
        public string SharingLinkCode { get; set; }
    }
}