using System;

namespace DrinkIt.Models
{
    public class AccountAchievements
    {
        public int Id { get; set; }

        public Achievement Achievement { get; set; }
        
        public DateTime Time { get; set; }
        
    }
}