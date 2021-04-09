using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkIt.Controllers
{
    public class DrinkController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}