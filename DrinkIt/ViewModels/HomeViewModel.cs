using System.Collections.Generic;
using DrinkIt.Models;

namespace DrinkIt.ViewModels
{
    public class HomeViewModel
    {
        public List<DrunkDrinks> Drinks { get; set; }
        public int IntakeGoal { get; set; }
        public int AlreadyDrunk { get; set; }
    }
}