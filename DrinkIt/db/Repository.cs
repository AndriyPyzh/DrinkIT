using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DrinkIt.Models;

namespace DrinkIt.db
{
    public class Repository : IRepository, IDisposable
    {
        private ApplicationDbContext _context;

        public Repository()
        {
            _context = new ApplicationDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Beverage> GetBeveragesOrderByNameAsc()
        {
            return _context.Beverages.OrderBy(d => d.Name).ToList();
        }

        public Beverage GetBeverageByName(string name)
        {
            return _context.Beverages.Single(b => b.Name.Equals(name));
        }

        public Account GetAccountByUser(string userId)
        {
            return _context
                .Users
                .Include(u => u.Account.DrunkDrinks)
                .Single(c => c.Id == userId)
                .Account;
        }

        public void UpdateAccount(Account account)
        {
            _context.Accounts.AddOrUpdate(account);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}