using System;

namespace DrinkIt.Models
{
    public class DrunkDrinks
    {
        public int Id { get; set; }

        public int Volume { get; set; }

        public DateTime Time { get; set; }

        public Beverage Beverage { get; set; }
    }
}