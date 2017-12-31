using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISZKR.Models
{
    public class ProfessionHistory
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Position { get; set; }
        public string EmployerName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        [Required]
        public virtual Person Person { get; set; }
    }
}