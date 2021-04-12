using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrinkIt.Models;
using DrinkIt.ViewModels;
using Microsoft.AspNet.Identity;

namespace DrinkIt.Controllers
{
    public class BeverageController : Controller
    {
        private ApplicationDbContext _context;

        public BeverageController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            List<Beverage> beverages = _context.Beverages
                .OrderBy(d => d.Name).ToList();
            return View(new AddDrinkViewModel {Beverages = beverages});
        }

        public ActionResult AddDrunkDrink(AddDrinkViewModel model)
        {
            int volume = int.Parse(model.Volume.Replace("ml", ""));
            Beverage beverage = _context.Beverages.Single(b => b.Name.Equals(model.Beverage));
            DateTime time = DateTime.Now;
            
            DrunkDrink drink = new DrunkDrink
            {
                Volume = volume,
                Beverage = beverage,
                Time = time
            };
            
            String userId = User.Identity.GetUserId();
            Account account = _context
                .Users
                .Include(u => u.Account.DrunkDrinks)
                .Single(c => c.Id == userId)
                .Account;
            
            account.DrunkDrinks.Add(drink);
            
            _context.Accounts.AddOrUpdate(account);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}