
using DrinkIt.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DrinkIt.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db;

        public ProfileController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Profile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                ApplicationUser user = db.Users.Single(u => u.Id.Equals(userId));

                Gender gender = db.Genders.Single(g => g.Name.Equals(model.Gender));
                var profile = new Account
                {
                    Age = model.Age,
                    Weight = model.Weight,
                    WakeUpTime = new System.TimeSpan(0,0,8,0),
                    SleepTime = new System.TimeSpan(0, 0, 22, 0),
                    Goal = model.Goal,
                    Gender = gender,
                    WaterNorm = model.Weight * 30
                    
                   
                };
                user.Account = profile;
                db.Accounts.Add(profile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
        
    }
}