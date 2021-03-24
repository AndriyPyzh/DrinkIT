using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.Models
{
    public class UserData
    {
        public UserData()
        {
        }

        public UserData( int waterNorm, TimeSpan sleep, TimeSpan wakeup, TimeSpan period, User user)
        {
            this.WaterNorm = waterNorm;
            this.SleepTime = sleep;
            this.WakeUpTime = wakeup;
            this.PeriodOfNotification = period;
            this.User = user;
        }
        
        public int Id { get; set; }
        public int WaterNorm { get; set; }
        public TimeSpan WakeUpTime { get; set; }
        public TimeSpan SleepTime { get; set; }
        public TimeSpan PeriodOfNotification { get; set; }
        public User User { get; set; }
    }
}