using System.Collections.Generic;
using DrinkIt.Models;

namespace DrinkIt.ViewModels
{
    public class HomeViewModel
    {
        public List<DrunkDrink> Drinks { get; set; }
        public int IntakeGoal { get; set; }
        public int AlreadyDrunk { get; set; }
    }
}