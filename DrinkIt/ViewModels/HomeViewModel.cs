using System;
using System.Collections.Generic;
using System.Linq;
using DrinkIt.Models;

namespace DrinkIt.ViewModels
{
    public class HomeViewModel
    {
        public List<DrunkDrink> Drinks { get; set; }
        public int IntakeGoal { get; set; }
        public int AlreadyDrunk { get; set; }

        public int BlogPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Drinks.Count / (double) BlogPerPage));
        }

        public List<DrunkDrink> PaginatedDrinks()
        {
            int start = (CurrentPage - 1) * BlogPerPage;
            return Drinks.Skip(start).Take(BlogPerPage).ToList();
        }
    }
}