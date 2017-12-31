using ISZKR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISZKR.Controllers
{
    public class BaseController : Controller
    {
        protected OutsideViewModel outsideViewModel;

        public BaseController()
        {
            outsideViewModel = new OutsideViewModel();
        }
    }
}