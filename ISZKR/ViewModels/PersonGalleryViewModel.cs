using System;
using ISZKR.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISZKR.ViewModels
{
    public class PersonGalleryViewModel
    {
        public Person person { get; set; }
        public Events events { get; set; }
        public List<Photo> photos { get; set; }

        public PersonGalleryViewModel()
        {
            photos = new List<Photo>();
        }
    }
}