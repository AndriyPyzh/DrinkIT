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

        public ActionResult Index(int page = 1)
        {
            return View(GenerateModel(page));
        }

        public ActionResult DeleteDrunkDrink(int page, int id)
        {
            DrunkDrink drink = _context.DrunkDrinks.SingleOrDefault(x => x.Id == id);
            _context.DrunkDrinks.Remove(drink);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home", new {page});
        }

        public HomeViewModel GenerateModel(int page)
        {
            String userId = User.Identity.GetUserId();

            Account account = _context
                .Users
                .Include(u => u.Account.DrunkDrinks.Select(d => d.Beverage))
                .Single(c => c.Id == userId)
                .Account;

            List<DrunkDrink> drinks = account
                .DrunkDrinks
                .Where(d => d.Time.Date == DateTime.Today)
                .OrderByDescending(d => d.Time)
                .ToList();

            int intakeGoal = Convert.ToInt32(account.Goal);

            int alreadyDrunked = drinks.Sum(d => d.Volume);

            return new HomeViewModel
            {
                BlogPerPage = 6,
                CurrentPage = page,
                Drinks = drinks,
                IntakeGoal = intakeGoal,
                AlreadyDrunk = alreadyDrunked
            };
        }
    }
}