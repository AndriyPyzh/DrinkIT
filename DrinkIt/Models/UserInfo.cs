using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.Models
{
    public class UserInfo
    {
        public UserInfo()
        {
        }

        public UserInfo(int age, double weight, double goal, DateTime dateOfBirth, Gender gender, User user)
        {
            this.Age = age;
            this.Weight = weight;
            this.Goal = goal;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.User = user;
        }
        
        public int Id { get; set; }
        
        [Required]
        public int Age { get; set; }
        
        [Required]
        public double Weight { get; set; }
        
        [Required]
        public double Goal { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public User User { get; set; }
    }
}