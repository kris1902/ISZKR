using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISZKR.ViewModels
{
    public class FamilyTreeViewModel
    {
        public string FathersName { get; set; }
        public string FathersSurname { get; set; }
        public string FathersPhotoURL { get; set; }
        public string MothersName { get; set; }
        public string MothersSurname { get; set; }
        public string MothersPhotoURL { get; set; }
        public string PersonPhotoURL { get; set; }
        public string PartnersName { get; set; }
        public string PartnersSurname { get; set; }
        public string PartnersPhotoURL { get; set; }
        public List<Models.Person> Kids { get; set; }
    }
}