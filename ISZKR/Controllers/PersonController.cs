using ISZKR.Models;
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
        public ActionResult Person(int id = 0)
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
            string personGender;
            int personMotherID;
            int personFatherID;
            int personPartnerID;
            PersonsRelativeViewModel vm = new PersonsRelativeViewModel
            {
                Person_list = new List<Person>(),
                person_id = personid
            };

            using (var context = new ISZKRDbContext())
            {
                personBirthDateTime = context.Person.Find(personid).BirthDateTime;
                personGender = context.Person.Find(personid).Gender;
                personMotherID = context.Person.Find(personid).MothersID;
                personFatherID = context.Person.Find(personid).FathersID;
                personPartnerID = context.Person.Find(personid).PartnerID;
            }

            switch (relative)
            {
                case "father":
                    using (var context = new ISZKRDbContext())
                    {
                        foreach (Person person in context.Person)
                        {
                            if (person.BirthDateTime < personBirthDateTime && person.Gender == "M" && person.ID != personPartnerID)
                            {
                                vm.Person_list.Add(person);
                            }
                        }
                    }
                    return PartialView("setPersonsFather", vm);
                case "mother":
                    using (var context = new ISZKRDbContext())
                    {
                        foreach (Person person in context.Person)
                        {
                            if (person.BirthDateTime < personBirthDateTime && person.Gender == "K" && person.ID != personPartnerID)
                            {
                                vm.Person_list.Add(person);
                            }
                        }
                    }
                    return PartialView("setPersonsMother", vm);
                case "partner":
                    using (var context = new ISZKRDbContext())
                    {
                        if (personGender == "M")
                        {
                            foreach (Person person in context.Person)
                            {
                                if (person.Gender == "K" && person.ID != personMotherID)
                                {
                                    vm.Person_list.Add(person);
                                }
                            }
                        }
                        else
                        {
                            foreach (Person person in context.Person)
                            {
                                if (person.Gender == "M" && person.ID != personFatherID)
                                {
                                    vm.Person_list.Add(person);
                                }
                            }
                        }

                    }
                    return PartialView("setPersonsPartner", vm);
                case "kid":
                    using (var context = new ISZKRDbContext())
                    {
                        foreach (Person person in context.Person)
                        {
                            if (person.BirthDateTime > personBirthDateTime && person.ID != personPartnerID && person.ID != personFatherID && person.ID != personMotherID)
                            {
                                vm.Person_list.Add(person);
                            }
                        }
                    }
                    return PartialView("setPersonsKid", vm);
                default:
                    return null;
            }



        }

        [HttpGet]
        public ActionResult EditFather(int person_id, int fathers_id)
        {
            if (fathers_id >= 0)
            {
                using (var context = new ISZKRDbContext())
                {
                    context.Person.Find(person_id).FathersID = fathers_id;
                    context.SaveChanges();
                }
            }
            return Redirect("/Person/" + person_id);
        }

        [HttpGet]
        public ActionResult EditMother(int person_id, int mothers_id)
        {
            if (mothers_id >= 0)
            {
                using (var context = new ISZKRDbContext())
                {
                    context.Person.Find(person_id).MothersID = mothers_id;
                    context.SaveChanges();
                }
            }
            return Redirect("/Person/" + person_id);
        }

        [HttpGet]
        public ActionResult EditPartner(int person_id, int partners_id)
        {
            if (partners_id >= 0)
            {
                using (var context = new ISZKRDbContext())
                {
                    context.Person.Find(person_id).PartnerID = partners_id;
                    context.Person.Find(partners_id).PartnerID = person_id;
                    context.SaveChanges();
                }
            }
            return Redirect("/Person/" + person_id);
        }

        [HttpGet]
        public ActionResult AddKid(int person_id, int kids_id)
        {
            if (kids_id >= 0)
            {
                using (var context = new ISZKRDbContext())
                {
                    if (context.Person.Find(person_id).Gender == "M")
                    {
                        context.Person.Find(kids_id).FathersID = person_id;
                    }
                    else
                    {
                        context.Person.Find(kids_id).MothersID = person_id;
                    }
                    context.SaveChanges();
                }
            }
            return Redirect("/Person/" + person_id);
        }

        [HttpGet]
        public ActionResult DeleteKid(int person_id, int kids_id)
        {
            using (var context = new ISZKRDbContext())
            {
                if (context.Person.Find(person_id).Gender == "M")
                {
                    context.Person.Find(kids_id).FathersID = 0;
                }
                else
                {
                    context.Person.Find(kids_id).MothersID = 0;
                }
                context.SaveChanges();
            }
            return Redirect("/Person/" + person_id);
        }

        [HttpGet]
        public ActionResult DeleteFather(int person_id)
        {
            using (var context = new ISZKRDbContext())
            {
                context.Person.Find(person_id).FathersID = 0;
                context.SaveChanges();
            }
            return Redirect("/Person/" + person_id);
        }

        [HttpGet]
        public ActionResult DeleteMother(int person_id)
        {
            using (var context = new ISZKRDbContext())
            {
                context.Person.Find(person_id).MothersID = 0;
                context.SaveChanges();
            }
            return Redirect("/Person/" + person_id);
        }

        [HttpGet]
        public ActionResult DeletePartner(int person_id)
        {
            using (var context = new ISZKRDbContext())
            {
                int partner_id = context.Person.Find(person_id).PartnerID;
                context.Person.Find(person_id).PartnerID = 0;
                context.Person.Find(partner_id).PartnerID = 0;
                context.SaveChanges();
            }
            return Redirect("/Person/" + person_id);
        }

        [ChildActionOnly]
        public ActionResult RenderTables(Person p)
        {
            PersonTablesViewModel vm = new PersonTablesViewModel();
            vm.person = p;
            using (var context = new ISZKRDbContext())
            {
                var edu = context.EducationHistory.Where(c => c.Person.ID == p.ID).ToList();
                foreach (var item in edu)
                {
                    vm.EducationHistoryList.Add(item);
                }

                var res = context.ResidenceHistory.Where(c => c.Person.ID == p.ID).ToList();
                foreach (var item in res)
                {
                    vm.ResidenceHistoryList.Add(item);
                }

                var pro = context.ProfessionHistory.Where(c => c.Person.ID == p.ID).ToList();
                foreach (var item in pro)
                {
                    vm.ProfessionHistoryList.Add(item);
                }
                //vm.ResidenceHistoryList = context.ResidenceHistory.Where(c => c.Person == p).ToList();
                //vm.ProfessionHistoryList = context.ProfessionHistory.Where(c => c.Person == p).ToList();
            }
            return PartialView("PersonTables", vm);
        }

        [HttpPost]
        public JsonResult AddOrEditEdu(string EducationLevel = "", string InstitutionName = "", string StartDateTime = "1900-01-01", string EndDateTime = "1900-01-01", int personID = 0, int eduID=0)
        {
            if (eduID == 0)
            {
                try
                {
                    EducationHistory new_edu = new EducationHistory
                    {
                        EducationLevel = EducationLevel,
                        InstitutionName = InstitutionName,
                        StartDateTime = DateTime.Parse(StartDateTime),
                        EndDateTime = DateTime.Parse(EndDateTime)
                    };

                    using (var context = new ISZKRDbContext())
                    {
                        new_edu.Person = context.Person.Find(personID);
                        context.EducationHistory.Add(new_edu);
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
            else
            {
                try
                {
                    using (var context = new ISZKRDbContext())
                    {
                        EducationHistory new_edu = context.EducationHistory.Find(eduID);

                        new_edu.EducationLevel = EducationLevel;
                        new_edu.InstitutionName = InstitutionName;
                        new_edu.StartDateTime = DateTime.Parse(StartDateTime);
                        new_edu.EndDateTime = DateTime.Parse(EndDateTime);
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
        }

        [HttpPost]
        public JsonResult DeleteEdu(int eduID)
        {
                try
                {
                    using (var context = new ISZKRDbContext())
                    {
                        EducationHistory edu = context.EducationHistory.Find(eduID);
                        context.EducationHistory.Attach(edu);
                        context.EducationHistory.Remove(edu);
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
        public JsonResult AddOrEditPro(string address = "", string empName = "", string position = "", string startDateTime = "1900-01-01", string endDateTime = "1900-01-01", int personID = 0, int workID=0)
        {
            if (workID == 0)
            {
                try
                {
                    ProfessionHistory new_pro = new ProfessionHistory
                    {
                        Address = address,
                        EmployerName = empName,
                        Position = position,
                        StartDateTime = DateTime.Parse(startDateTime),
                        EndDateTime = DateTime.Parse(endDateTime)
                    };

                    using (var context = new ISZKRDbContext())
                    {
                        new_pro.Person = context.Person.Find(personID);
                        context.ProfessionHistory.Add(new_pro);
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
            else
            {
                try
                {
                    using (var context = new ISZKRDbContext())
                    {
                        ProfessionHistory new_pro = context.ProfessionHistory.Find(workID);

                        new_pro.Address = address;
                        new_pro.EmployerName = empName;
                        new_pro.Position = position;
                        new_pro.StartDateTime = DateTime.Parse(startDateTime);
                        new_pro.EndDateTime = DateTime.Parse(endDateTime);
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
        }

        [HttpPost]
        public JsonResult DeleteWork(int workID)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    ProfessionHistory pro = context.ProfessionHistory.Find(workID);
                    context.ProfessionHistory.Attach(pro);
                    context.ProfessionHistory.Remove(pro);
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

        public JsonResult AddOrEditRes(string address, string city, string country, string StartDateTime, string EndDateTime, int personID=0, int resID=0)
        {
            if (StartDateTime == "") StartDateTime = "1900-01-01";
            if (EndDateTime == "") EndDateTime = "1900-01-01";
            if (resID == 0)
            {
                try
                {
                    ResidenceHistory new_res = new ResidenceHistory
                    {
                        Address = address,
                        City = city,
                        Country = country,
                        StartDateTime = DateTime.Parse(StartDateTime),
                        EndDateTime = DateTime.Parse(EndDateTime)
                    };

                    using (var context = new ISZKRDbContext())
                    {
                        new_res.Person = context.Person.Find(personID);
                        context.ResidenceHistory.Add(new_res);
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
            else
            {
                try
                {
                    using (var context = new ISZKRDbContext())
                    {
                        ResidenceHistory new_res = context.ResidenceHistory.Find(resID);
                        new_res.Address = address;
                        new_res.City = city;
                        new_res.Country = country;
                        new_res.StartDateTime = DateTime.Parse(StartDateTime);
                        new_res.EndDateTime = DateTime.Parse(EndDateTime);
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
        }

        [HttpPost]
        public JsonResult DeleteRes(int resID)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    ResidenceHistory res = context.ResidenceHistory.Find(resID);
                    context.ResidenceHistory.Attach(res);
                    context.ResidenceHistory.Remove(res);
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
    }
}
