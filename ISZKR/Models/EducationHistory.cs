using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISZKR.Models
{
    public class EducationHistory
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool Completed { get; set; }
        public string InstitutionName { get; set; }
        [Required]
        public virtual Person Person { get; set; }
        public virtual SchoolTypes SchoolType { get; set; }
    }
    public class SchoolTypes
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EducationLevelName { get; set; }
    }
}