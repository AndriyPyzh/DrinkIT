using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using DrinkIt.Models;
using Microsoft.AspNet.Identity;

namespace DrinkIt.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            String userId = User.Identity.GetUserId();
            List<DrunkDrinks> drinks = _context
                .Users
                .Include(u => u.Account.DrunkDrinks.Select(d => d.Beverage))
                .Single(c => c.Id == userId)
                .Account
                .DrunkDrinks.ToList();
            
            return View(drinks);
        }
    }
}