using ISZKR.Models;
using ISZKR.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISZKR.Controllers
{
    public class PersonController : BaseController
    {
        // GET: Person
        public ActionResult Person(int id=0)
        {
            if (id != 0)
            {
                var person = new Person();

                using (var context = new ISZKRDbContext())
                {
                    person = context.Person.Find(id);
                }

                outsideViewModel.Person = person;
                outsideViewModel.FamilyTreeViewModel = BuildFamilyTree(id);
                return View(outsideViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");   //Tutaj będzie przeniesienie do listy osób
            }
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private FamilyTreeViewModel BuildFamilyTree(int PersonID)
        {
            FamilyTreeViewModel vm = new FamilyTreeViewModel();
            using (var context = new ISZKRDbContext())
            {
                //Father
                vm.FathersName = (from p in context.Person
                                  where p.ID == outsideViewModel.Person.FathersID
                                  select p.Name).SingleOrDefault();
                vm.FathersSurname = (from p in context.Person
                                  where p.ID == outsideViewModel.Person.FathersID
                                  select p.Surname).SingleOrDefault();
                vm.FathersPhotoURL = (from p in context.Person
                                      where p.ID == outsideViewModel.Person.FathersID
                                      select p.PhotoURL).SingleOrDefault();
                //Mother
                vm.MothersName = (from p in context.Person
                                where p.ID == outsideViewModel.Person.MothersID
                                select p.Name).SingleOrDefault();
                vm.MothersSurname = (from p in context.Person
                                   where p.ID == outsideViewModel.Person.MothersID
                                   select p.Surname).SingleOrDefault();
                vm.MothersPhotoURL = (from p in context.Person
                                      where p.ID == outsideViewModel.Person.MothersID
                                      select p.PhotoURL).SingleOrDefault();
                //Partner
                vm.PartnersName = (from p in context.Person
                                where p.ID == outsideViewModel.Person.PartnerID
                                select p.Name).SingleOrDefault();
                vm.PartnersSurname = (from p in context.Person
                                   where p.ID == outsideViewModel.Person.PartnerID
                                      select p.Surname).SingleOrDefault();
                vm.PartnersPhotoURL = (from p in context.Person
                                       where p.ID == outsideViewModel.Person.PartnerID
                                       select p.PhotoURL).SingleOrDefault();
                //Kids
                vm.Kids = (from p in context.Person
                          where p.FathersID == PersonID || p.MothersID == PersonID
                          select p).ToList();
                //Person photo
                vm.PersonPhotoURL = (from p in context.Person
                                     where p.ID == PersonID
                                     select p.PhotoURL).SingleOrDefault();
            }
            return vm;
        }
    }
}
