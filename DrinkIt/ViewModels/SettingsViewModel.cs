using System;
using System.ComponentModel.DataAnnotations;
using DrinkIt.Models;

namespace DrinkIt.ViewModels
{
    public class SettingsViewModel
    {
        //   [Required]
        [Display(Name = "Age")] public int Age { get; set; }

        // [Required]
        [Display(Name = "Weight")] public double Weight { get; set; }

        //  [Required]
        [Display(Name = "Gender")] public string Gender { get; set; }

        // [Required]
        [Display(Name = "Goal")] public double Goal { get; set; }

        //[Required]
        [Display(Name = "WakeUpTime")] public TimeSpan WakeUpTime = new TimeSpan(0, 0, 8, 0);

        //[Required]
        [Display(Name = "SleepTime")] public TimeSpan SleepTime = new TimeSpan(0, 0, 22, 0);
    }
}