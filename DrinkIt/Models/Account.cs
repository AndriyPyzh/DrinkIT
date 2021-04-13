using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrinkIt.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int WaterNorm { get; set; }

        public TimeSpan WakeUpTime { get; set; }

        public TimeSpan SleepTime { get; set; }

        public TimeSpan PeriodOfNotification { get; set; }

        [Required] public int Age { get; set; }

        [Required] public double Weight { get; set; }

        [Required] public double Goal { get; set; }
        

        public Gender Gender { get; set; }
        
        
        public IList<DrunkDrink> DrunkDrinks { get; set; }

        public IList<AccountAchievements> Achievements { get; set; }
    }
}