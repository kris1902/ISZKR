using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISZKR.Models
{
    public class ResidenceHistory
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        [Required]
        public virtual Person Person { get; set; }
    }
}