using System.Collections.Generic;
using DrinkIt.Models;

namespace DrinkIt.db
{
    public interface IRepository
    {
        List<Beverage> GetBeveragesOrderByNameAsc();

        Beverage GetBeverageByName(string name);

        Account GetAccountByUser(string userId);

        void UpdateAccount(Account account);

        void SaveChanges();
    }
}