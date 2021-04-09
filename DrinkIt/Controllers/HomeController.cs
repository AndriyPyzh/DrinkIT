using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using DrinkIt.Models;
using DrinkIt.ViewModels;
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
            Account account = _context
                .Users
                .Include(u => u.Account.DrunkDrinks.Select(d => d.Beverage))
                .Single(c => c.Id == userId)
                .Account;
            List<DrunkDrinks> drinks = account
                .DrunkDrinks
                .OrderByDescending(d=>d.Time)
                .ToList();
            int intakeGoal = Convert.ToInt32(account.Goal);
            int alreadyDrunked = drinks.Sum(d => d.Volume);

            return View(new HomeViewModel
            {
                Drinks = drinks,
                IntakeGoal = intakeGoal,
                AlreadyDrunk = alreadyDrunked
            });
        }
    }
}