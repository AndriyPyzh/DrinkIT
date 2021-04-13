using System.Collections.Generic;
using DrinkIt.Models;

namespace DrinkIt.ViewModels
{
    public class AddDrinkViewModel
    {
        public string Beverage { get; set; }
        public string Volume { get; set; }
        public List<Beverage> Beverages { get; set; }
    }
}