using System;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using DrinkIt.Models;
using DrinkIt.ViewModels;
using Microsoft.AspNet.Identity;
namespace DrinkIt.Controllers
{
    public class SettingsController : Controller
    {
        private ApplicationDbContext _context;

        public SettingsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET
        public ActionResult Index(int page = 2)
        {
            return View(GenerateModel(page));
        }
        public SettingsViewModel GenerateModel(int page)
        {
            String userId = User.Identity.GetUserId();

            Account account = _context
                .Users
                .Include(u => u.Account.Gender)
                .Single(c => c.Id == userId)
                .Account;
            
           Gender gender = _context.Genders.Single(g => g.Name.Equals(account.Gender.Name));
            return new SettingsViewModel()
            {
                Weight = account.Weight,
                Age = account.Age,
                SleepTime = account.SleepTime,
                WakeUpTime = account.WakeUpTime,
                Goal = account.Goal,
                Gender = gender.Name
   
            };
        }
        public async Task<ActionResult> Save(SettingsViewModel model)
        {
            String userId = User.Identity.GetUserId();

            Account account = _context
                .Users
                .Include(u => u.Account.Gender)
                .Single(c => c.Id == userId)
                .Account;
            Gender gender = _context.Genders.Single(g => g.Name.Equals(model.Gender));
            account.Age = model.Age;
            account.Goal = model.Goal;
            account.Weight = model.Weight;
            account.SleepTime = model.SleepTime;
            account.WakeUpTime = model.WakeUpTime;
            account.Gender = gender;
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}