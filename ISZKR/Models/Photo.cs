﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISZKR.Models
{
    public class Photo
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Path { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        [Required]
        public virtual Chronicle Chronicle { get; set; }
        public virtual Events Events { get; set; }
    }
}