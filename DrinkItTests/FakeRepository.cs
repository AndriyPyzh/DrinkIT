using System.Collections.Generic;
using System.Linq;
using DrinkIt.db;
using DrinkIt.Models;

namespace DrinkItTests
{
    class FakeRepository : IRepository
    {
        public List<Beverage> Beverages { get; set; }
        public List<Account> Accounts { get; set; }
        public List<ApplicationUser> Users { get; set; }

        public FakeRepository()
        {
            Beverages = new List<Beverage>();
            Accounts = new List<Account>();
            Users = new List<ApplicationUser>();
        }
        public List<Beverage> GetBeveragesOrderByNameAsc()
        {
            return Beverages.OrderBy(b => b.Name).ToList();
        }

        public Beverage GetBeverageByName(string name)
        {
            return Beverages.Find(b => b.Name.Equals(name));
        }

        public Account GetAccountByUser(string userId)
        {
            return new Account();
        }

        public void UpdateAccount(Account account)
        {
            int index = Accounts.FindIndex(a => a.Id == account.Id);
            if (index >= 0)
            {
                Accounts[index] = account;
            }
        }

        public void SaveChanges()
        {
        }
    }
}