﻿using ISZKR.Models;
using ISZKR.ViewModels;
using Microsoft.AspNet.Identity;
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
        [Route("Person/{id:int}")]
        public ActionResult Person(int id=0)
        {
            if (isPersonExist(id))
            {
                var person = new Person();
                int usersChronicleID;

                using (var context = new ISZKRDbContext())
                {
                    person = context.Person.Find(id);

                    if (true)   //Miejsce na sprawdzenie tożsamości użytkownika (czy może oglądać tą rzecz)
                    {
                        outsideViewModel.Person = person;
                        outsideViewModel.FamilyTreeViewModel = BuildFamilyTree(id);
                        return View(outsideViewModel);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");   //Tutaj będzie przeniesienie do listy osób
            }
        }



        private bool isPersonExist(int id)
        {
            if (id == 0)
            {
                return false;
            }
            using (var context = new ISZKRDbContext())
            {
                if (context.Person.Any(p => p.ID == id))
                {
                    return true;
                }
            }
            return false;
        }

        public ActionResult Create()
        {
            int id;
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Person new_person = new Person
                    {
                        Name = "Imię",
                        Surname = "Nazwisko",
                        Gender = "M",
                        BirthDateTime = DateTime.Parse("1900-01-01"),
                        DeathDateTime = DateTime.Parse("1900-01-01"),
                        Description = "Tutaj napisz coś o tej osobie...",
                        FathersID = 0,
                        MothersID = 0,
                        PartnerID = 0
                        //Jeszcze trzeba przekazać ID kroniki jakoś
                    };
                    context.Person.Add(new_person);
                    id = new_person.ID;
                    context.SaveChanges();
                }
                return RedirectToAction("Person", id);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditName(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Person person = context.Person.Find(outsideViewModel.Person.ID);

                    person.Name = outsideViewModel.Person.Name;
                    person.Surname = outsideViewModel.Person.Surname;
                    person.FamilySurname = outsideViewModel.Person.FamilySurname;

                    context.Set<Person>().Attach(person);
                    context.Entry(person).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return Json(new
            {
                result = "success"
            });
        }

        [HttpPost]
        public ActionResult EditBirth(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Person person = context.Person.Find(outsideViewModel.Person.ID);

                    person.BirthDateTime = outsideViewModel.Person.BirthDateTime;
                    person.BirthPlace = outsideViewModel.Person.BirthPlace;

                    context.Set<Person>().Attach(person);
                    context.Entry(person).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Json(new
            {
                result = "success"
            });
        }

        [HttpPost]
        public ActionResult EditDeath(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Person person = context.Person.Find(outsideViewModel.Person.ID);

                    person.DeathDateTime = outsideViewModel.Person.DeathDateTime;
                    person.DeathPlace = outsideViewModel.Person.DeathPlace;

                    context.Set<Person>().Attach(person);
                    context.Entry(person).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Json(new
            {
                result = "success"
            });
        }

        [HttpPost]
        public ActionResult EditBurial(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Person person = context.Person.Find(outsideViewModel.Person.ID);
                    
                    person.RestingPlace = outsideViewModel.Person.RestingPlace;

                    context.Set<Person>().Attach(person);
                    context.Entry(person).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Json(new
            {
                result = "success"
            });
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
        [HttpGet]
        public ActionResult setPersonsRelative(int personid, string relative)
        {
            DateTime personBirthDateTime;
            PersonsRelativeViewModel vm = new PersonsRelativeViewModel();
            vm.Person_list = new List<Person>();
            using (var context = new ISZKRDbContext())
            {
                personBirthDateTime = context.Person.Find(personid).BirthDateTime;
            }
            using (var context = new ISZKRDbContext())
            {
                //Dopisywanie do listy wyboru kobiet starszych od osoby
                foreach (Person person in context.Person)
                {
                    if (person.BirthDateTime < personBirthDateTime && person.Gender == "M")
                    {
                        vm.Person_list.Add(person);
                    }
                }
            }
            return PartialView(vm);
        }
        
    }
}
