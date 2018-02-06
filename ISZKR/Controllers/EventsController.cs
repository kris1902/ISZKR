using ISZKR.Models;
using ISZKR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ISZKR.Controllers
{
    public class EventsController : BaseController
    {
        [Route("Events/{id:int}")]
        public ActionResult Events(int id=0)
        {
            if (isEventsExist(id))
            {
                var events = new Events();
                List<int> personIds = new List<int>();

                personIds.Add(7);
                personIds.Add(9);

                using (var context = new ISZKRDbContext())
                {
                    events = context.Events.Find(id);

                    //var model = context.Person.Where(x => x.EventParticipant.Contains(events)).ToList();

                    //var model = context.Events.Include(c => c.MainEventParticipants)
                    //    .Single(c => c.ID == events.ID);

                    //context.Entry(model).CurrentValues.SetValues(events);

                    //foreach (var mainEventParticipantInDb in model.MainEventParticipants.ToList())
                    //{
                    //    if ()
                    //}

                    //foreach (var personID in personIds)
                    //{
                    //    if (!model.MainEventParticipants.Any(c => c.ID == personID))
                    //    {
                    //        var person = context.Person.Find(personID);
                    //        model.MainEventParticipants.Add(person);
                    //    }
                    //}

                    //context.Events.Find(id).MainEventParticipants = new List<Person>();
                    //Person p1 = context.Person.Find(7);
                    //Person p2 = context.Person.Find(9);
                    //context.Events.Find(id).MainEventParticipants.Add(p1);
                    //context.Events.Find(id).MainEventParticipants.Add(p2);
                    outsideViewModel.Events = events;
                    //context.SaveChanges();

                    if (true)   //Miejsce na sprawdzenie tożsamości użytkownika (czy może oglądać tą rzecz)
                    {
                        outsideViewModel.Events = events;
                        outsideViewModel.MainPersonsListFromEvent = events.MainEventParticipants.ToList();
                        outsideViewModel.PersonsListFromEvents = events.EventParticipants.ToList();
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

        public ActionResult Create(int chronicleID = 10, string title="Nowe zdarzenie")
        {
            int id;
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Events new_events = new Events
                    {
                        Title = title,
                        StartDateTime = DateTime.Parse("1900-01-01"),
                        EndDateTime = DateTime.Parse("1900-01-01"),
                        Chronicle = context.Chronicle.Find(chronicleID)
                    };
                    context.Events.Add(new_events);
                    context.SaveChanges();
                    id = new_events.ID;
                }
                return Redirect("/Events/" + id);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditDescription(string description, int eventsID)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Events events = context.Events.Find(eventsID);

                    events.Content = description;

                    context.Set<Events>().Attach(events);
                    context.Entry(events).State = System.Data.Entity.EntityState.Modified;

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

        private bool isEventsExist(int id)
        {
            if (id == 0)
            {
                return false;
            }
            using (var context = new ISZKRDbContext())
            {
                if (context.Events.Any(e => e.ID == id))
                {
                    return true;
                }
            }
            return false;
        }

        //private List<Person> getParticipants(int eventsID)
        //{

        //}

        [HttpPost]
        public ActionResult EditTitle(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Events events = context.Events.Find(outsideViewModel.Events.ID);

                    events.Title = outsideViewModel.Events.Title;

                    context.Set<Events>().Attach(events);
                    context.Entry(events).State = System.Data.Entity.EntityState.Modified;

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
        public ActionResult EditPlace(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Events events = context.Events.Find(outsideViewModel.Events.ID);

                    events.Place = outsideViewModel.Events.Place;

                    context.Set<Events>().Attach(events);
                    context.Entry(events).State = System.Data.Entity.EntityState.Modified;

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
        public ActionResult EditStart(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Events events = context.Events.Find(outsideViewModel.Events.ID);

                    events.StartDateTime = outsideViewModel.Events.StartDateTime;

                    context.Set<Events>().Attach(events);
                    context.Entry(events).State = System.Data.Entity.EntityState.Modified;

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
        public ActionResult EditEnd(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Events events = context.Events.Find(outsideViewModel.Events.ID);

                    events.EndDateTime = outsideViewModel.Events.EndDateTime;

                    context.Set<Events>().Attach(events);
                    context.Entry(events).State = System.Data.Entity.EntityState.Modified;

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
        public ActionResult EditDates(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Events events = context.Events.Find(outsideViewModel.Events.ID);

                    events.StartDateTime = outsideViewModel.Events.StartDateTime;
                    events.EndDateTime = outsideViewModel.Events.EndDateTime;

                    context.Set<Events>().Attach(events);
                    context.Entry(events).State = System.Data.Entity.EntityState.Modified;

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
        public ActionResult EditMainParticipants(OutsideViewModel outsideViewModel)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Events events = context.Events.Find(outsideViewModel.Events.ID);

                    //>>>>????<<<<<

                    context.Set<Events>().Attach(events);
                    context.Entry(events).State = System.Data.Entity.EntityState.Modified;

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
        public JsonResult AddPersonToMainParticipants(int eventsID, int personID)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Person person = context.Person.Find(personID);
                    context.Events.Find(eventsID).MainEventParticipants.Add(person);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return Json(new
                {
                    result = "failure"
                });
            }
            return Json(new
            {
                result = "success"
            });
        }

        [HttpPost]
        public JsonResult RemovePersonFromMainParticipants(int eventsID, int personID)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Person person = context.Person.Find(personID);
                    context.Events.Find(eventsID).MainEventParticipants.Remove(person);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return Json(new
                {
                    result = "failure"
                });
            }
            return Json(new
            {
                result = "success"
            });
        }

        [HttpPost]
        public JsonResult AddPersonToParticipants(int eventsID, int personID)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Person person = context.Person.Find(personID);
                    context.Events.Find(eventsID).EventParticipants.Add(person);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return Json(new
                {
                    result = "failure"
                });
            }
            return Json(new
            {
                result = "success"
            });
        }

        [HttpPost]
        public JsonResult RemovePersonFromParticipants(int eventsID, int personID)
        {
            try
            {
                using (var context = new ISZKRDbContext())
                {
                    Person person = context.Person.Find(personID);
                    context.Events.Find(eventsID).EventParticipants.Remove(person);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return Json(new
                {
                    result = "failure"
                });
            }
            return Json(new
            {
                result = "success"
            });
        }

        public ActionResult MainEventsList(int eventsID)
        {
            List<Person> persons_in_events = new List<Person>();
            List<Person> main_persons_in_events = new List<Person>();
            EventsViewModel vm = new EventsViewModel();
            Events events = new Events();
            using (var context = new ISZKRDbContext())
            {
                events = context.Events.Find(eventsID);
                vm.AllPerson = context.Person.Where(p => p.ID != 0).ToList();   //Wszyskie osoby
                main_persons_in_events = events.MainEventParticipants.ToList();
                persons_in_events = main_persons_in_events.Concat(events.EventParticipants).ToList();
                foreach (Person person in persons_in_events)
                {
                    vm.AllPerson.RemoveAll(p => p.ID == person.ID); //Usuń z listy ogólnej jeżeli już znajduje się w zdarzeniu.
                }
            }
            vm.MainEventsParticipantsList = main_persons_in_events;
            vm.eventsID = eventsID;
            return PartialView("_MainEventsParticipantsEdit", vm);
        }

        public ActionResult EventsList(int eventsID)
        {
            List<Person> persons_in_events = new List<Person>();
            List<Person> other_persons_in_events = new List<Person>();
            EventsViewModel vm = new EventsViewModel();
            Events events = new Events();
            using (var context = new ISZKRDbContext())
            {
                events = context.Events.Find(eventsID);
                vm.AllPerson = context.Person.Where(p => p.ID != 0).ToList();   //Wszyskie osoby
                other_persons_in_events = events.EventParticipants.ToList();
                persons_in_events = other_persons_in_events.Concat(events.MainEventParticipants).ToList();
                foreach (Person person in persons_in_events)
                {
                    vm.AllPerson.RemoveAll(p => p.ID == person.ID); //Usuń z listy ogólnej jeżeli już znajduje się w zdarzeniu.
                }
            }
            vm.EventsParticipantsList = other_persons_in_events;
            vm.eventsID = eventsID;
            return PartialView("_EventsParticipantsEdit", vm);
        }

        [ChildActionOnly]
        public ActionResult RenderGallery(Events e)
        {
            PersonGalleryViewModel vm = new PersonGalleryViewModel();
            using (var context = new ISZKRDbContext())
            {
                e = context.Events.Find(e.ID);
                vm.events = e;
                var list_of_photos = context.Photo.Where(p => p.Events.ID != null).ToList();
                foreach (var photo in list_of_photos)
                {
                    vm.photos.Add(photo);
                }
            }
            return PartialView("_EventsGallery", vm);
        }

        public RedirectToRouteResult RemoveEventsFromPhoto(int photoID)
        {
            int eventsID;
            using (var context = new ISZKRDbContext())
            {
                eventsID = context.Photo.Find(photoID).Events.ID;
                context.Photo.Find(photoID).Events = null;
                context.SaveChanges();
            }
            return RedirectToAction("Events", "Events", new { id=eventsID });
        }
    }
}

