using ISZKR.Models;
using System.Collections.Generic;

namespace ISZKR.ViewModels
{
    public class PersonsRelativeViewModel
    {
        public List<Person> Person_list {get; set;}
        public int person_id { get; set; }
        public bool personHasSibling { get; set; }
    }
}