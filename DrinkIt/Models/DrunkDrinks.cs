using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.Models
{
    public class DrunkDrinks
    {
        public DrunkDrinks()
        {
        }

        public DrunkDrinks(int volume, DateTime now, Beverage beverage, User username)
        {
            this.Volume = volume;
            this.Time = now;
            this.Beverage = beverage;
            this.User = username;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int Volume { get; set; }
        
        public DateTime Time { get; set; }
        
        public Beverage Beverage { get; set; }
        
        public User User { get; set; } 
    }
}