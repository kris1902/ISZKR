using ISZKR.Models;
using ISZKR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISZKR.Extensions;

namespace ISZKR.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            if (User.Identity.IsAuthenticated)
            {
                int userChronicleID = Convert.ToInt32(User.Identity.GetUsersChronicleId());
                using (var context = new ISZKRDbContext())
                {
                    ViewBag.MenQuantity = context.Person.Where(p => p.Chronicle.ID == userChronicleID && p.Gender == "M").Count();
                    ViewBag.WomenQuantity = context.Person.Where(p => p.Chronicle.ID == userChronicleID && p.Gender == "K").Count();
                    ViewBag.PersonsQuantity = context.Person.Where(p => p.Chronicle.ID == userChronicleID).Count();
                    ViewBag.EventsQuantity = context.Events.Where(e => e.Chronicle.ID == userChronicleID).Count();
                    ViewBag.PhotosQuantity = context.Photo.Where(p => p.Chronicle.ID == userChronicleID).Count();
                    ViewBag.LastAddedPersons = context.Person.OrderByDescending(p => p.ID).Where(p => p.Chronicle.ID == userChronicleID).Take(10).ToList();
                    ViewBag.LastAddedEvents = context.Events.OrderByDescending(e => e.ID).Where(e => e.Chronicle.ID == userChronicleID).Take(10).ToList();
                }
            }
            return View(outsideViewModel);
        }

        public ActionResult Instructions()
        {
            return View();
        }
    }
}