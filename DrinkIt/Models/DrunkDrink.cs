using System;

namespace DrinkIt.Models
{
    public class DrunkDrink
    {
        public int Id { get; set; }

        public int Volume { get; set; }

        public DateTime Time { get; set; }

        public Beverage Beverage { get; set; }
    }
}