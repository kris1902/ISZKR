﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISZKR.Models
{
    public class Events
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual Chronicle Chronicle { get; set; }
        public virtual ICollection<Person> MainEventParticipants { get; set; }
        public virtual ICollection<Person> EventParticipants { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDateTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDateTime { get; set; }
        public string Place { get; set; }
    }
}