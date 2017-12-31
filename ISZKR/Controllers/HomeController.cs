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
            outsideViewModel.Person = new Person();

            return View(outsideViewModel);
        }
    }
}