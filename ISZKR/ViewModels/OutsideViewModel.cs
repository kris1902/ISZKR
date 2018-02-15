using ISZKR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISZKR.ViewModels
{
    public class OutsideViewModel
    {
        public OutsideViewModel()
        {
            LoginAndRegisterViewModel = new LoginAndRegisterViewModel
            {
                loginViewModel = new LoginViewModel()
            };
        }
        public ApplicationUser User { get; }
        public LoginAndRegisterViewModel LoginAndRegisterViewModel { get; set; }
        public Person Person { get; set; }
        public Events Events { get; set; }
        public FamilyTreeViewModel FamilyTreeViewModel { get; set; }
        public PersonTablesViewModel PersonTablesViewModel { get; set; }
        public PersonPanelsViewModel PersonPanelsViewModel { get; set; }
        public ChronicleViewModel ChronicleViewModel { get; set; }
        public SearchViewModel SearchViewModel { get; set; }
        public List<Person> PersonsListFromEvents { get; set; }
        public List<Person> MainPersonsListFromEvent { get; set; }
        public FileModel FileModel { get; set; }
    }
}