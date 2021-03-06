﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISZKR.Models
{
    public class Person
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDateTime { get; set; }
        public string BirthPlace { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeathDateTime { get; set; }
        public string DeathPlace { get; set; }
        public string PhotoURL { get; set; }
        public string FamilySurname { get; set; }
        public int FathersID { get; set; }
        public int MothersID { get; set; }
        public int PartnerID { get; set; }
        public string Description { get; set; }
        public string RestingPlace { get; set; }
        public virtual ICollection<Photo> IsOnPhotos { get; private set; }
        public virtual ICollection<Events> EventMainParticipant { get; private set; }
        public virtual ICollection<Events> EventParticipant { get; private set; }
        [Required]
        public virtual Chronicle Chronicle { get; set; }
    }
}