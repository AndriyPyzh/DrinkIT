using System;
using System.ComponentModel.DataAnnotations;
using DrinkIt.Models;

namespace DrinkIt.ViewModels
{
    public class SettingsViewModel
    {
        [Range(7, 99, ErrorMessage = "Age must be more than 7")]
        [Display(Name = "Age")] public int Age { get; set; }

        [Range(40, 200, ErrorMessage = "Weight must be between 40 and 200")]
        [Display(Name = "Weight")] public double Weight { get; set; }

        [Required(ErrorMessage = "Select your gender")]
        [Display(Name = "Gender")] public string Gender { get; set; }

        [Range(500, 5000, ErrorMessage = "Goal must be between 500 and 5000")]
        [Display(Name = "Goal")] public double Goal { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Wake up time must be in time foramt")]
        [Display(Name = "WakeUpTime")] public TimeSpan WakeUpTime { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Sleep time must be in time foramt")]
        [Display(Name = "SleepTime")] public TimeSpan SleepTime { get; set; }
    }
}