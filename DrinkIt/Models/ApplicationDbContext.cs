using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DrinkIt.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<DrunkDrink> DrunkDrinks { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}