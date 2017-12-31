using ISZKR.Models;
using ISZKR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISZKR.Controllers
{
    public class PersonController : BaseController
    {
        // GET: Person
        public ActionResult Person()
        {
            //using (var context = new ISZKRDbContext())
            //{
            //    var chronicle = context.Chronicle.Find(2);
            //    var person = new Person()
            //    {
            //        Name = "Janusz",
            //        Surname = "Wolszczak",
            //        BirthDateTime = DateTime.Now,
            //        DeathDateTime = DateTime.Now,
            //        MarriageDateTime = DateTime.Now,
            //        Chronicle = chronicle
            //    };

            //    context.Person.Add(person);
            //    context.SaveChanges();
            //}
            var person = new Person();

            using (var context = new ISZKRDbContext())
            {
                person = context.Person.Find(3);
            }

            outsideViewModel.Person = person;

            return View(outsideViewModel);
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
    }
}
