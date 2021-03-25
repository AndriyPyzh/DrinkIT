using System.Collections.Generic;
using System.Web.Mvc;
using DrinkIt.Models;
using DrinkIt.ViewModels;

namespace DrinkIt.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            return View();    
        }
    }
}