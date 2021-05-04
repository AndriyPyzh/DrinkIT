using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using DrinkIt.Models;
using DrinkIt.ViewModels;
using Microsoft.AspNet.Identity;

namespace DrinkIt.Controllers
{
    public class StatisticsController : Controller
    {
        private ApplicationDbContext _context;

        public StatisticsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(String day, int page = 1)
        {
            return View(GenerateModel(page, day));
        }

        public HomeViewModel GenerateModel(int page, String day)
        {

            DateTime searchDay = DateTime.Now;
            if (day != null)
            {
                searchDay = DateTime.ParseExact(day, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            String userId = User.Identity.GetUserId();

            Account account = _context
                .Users
                .Include(u => u.Account.DrunkDrinks.Select(d => d.Beverage))
                .Single(c => c.Id == userId)
                .Account;

            List<DrunkDrink> drinks = account
                .DrunkDrinks
                .Where(d => d.Time.Date == searchDay.Date)
                .OrderByDescending(d => d.Time)
                .ToList();

            int intakeGoal = Convert.ToInt32(account.Goal);

            int alreadyDrunk = drinks.Sum(d => d.Volume);

            return new HomeViewModel
            {
                DrinksPerPage = 6,
                CurrentPage = page,
                Drinks = drinks,
                IntakeGoal = intakeGoal,
                AlreadyDrunk = alreadyDrunk,
                Day = searchDay
            };
        }
    }
}