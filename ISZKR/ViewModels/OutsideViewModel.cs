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
        public FamilyTreeViewModel FamilyTreeViewModel { get; set; }
    }
}