using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrinkIt.db;
using DrinkIt.Models;
using DrinkIt.ViewModels;
using Microsoft.AspNet.Identity;

namespace DrinkIt.Controllers
{
    public class BeverageController : Controller
    {
        private IRepository _repository;

        public BeverageController()
        {
            _repository = new Repository();
        }
        
        public BeverageController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(GetBeverages());
        }

        public AddDrinkViewModel GetBeverages()
        {
            List<Beverage> beverages = _repository.GetBeveragesOrderByNameAsc();
            return new AddDrinkViewModel {Beverages = beverages};
        }

        public ActionResult AddDrunkDrink(AddDrinkViewModel model)
        {
            int volume = int.Parse(model.Volume.Replace("ml", ""));
            Beverage beverage = _repository.GetBeverageByName(model.Beverage);
            DateTime time = DateTime.Now;
            
            DrunkDrink drink = new DrunkDrink
            {
                Volume = volume,
                Beverage = beverage,
                Time = time
            };
            
            String userId = User.Identity.GetUserId();
            Account account = _repository.GetAccountByUser(userId);
            
            account.DrunkDrinks.Add(drink);
            
            _repository.UpdateAccount(account);
            _repository.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}