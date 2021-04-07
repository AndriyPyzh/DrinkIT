using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkIt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() 
        { 
            var staticPageToRender = new FilePathResult("Views/Pages/home-page.html", "text/html"); 
            return staticPageToRender;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}