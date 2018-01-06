using ISZKR.Models;
using ISZKR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISZKR.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //Dodawanie osoby
            //using (var context = new ISZKRDbContext())
            //{
            //    context.Person.Add(
            //        new Person
            //        {
            //            Name = "Teresa",
            //            Surname = "Dubiel",
            //            Gender = 'K',
            //            BirthDateTime = DateTime.Parse("1930-08-24"),
            //            BirthPlace = "Dobrzyca",
            //            DeathDateTime = DateTime.Parse("2005-11-27"),
            //            DeathPlace = "Chorzów",
            //            FamilySurname = "Bury",
            //            RestingPlace = "Cmentarz przy parafii św. Barbary w Chorzowie"
            //        }
            //    );
            //    context.SaveChanges();
            //}
            return View(outsideViewModel);
        }
    }
}