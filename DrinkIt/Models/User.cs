using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.Models
{
    public class User
    {
        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        //[MinLength(5)]
        //[MaxLength(20)]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        public UserData UserData { get; set; }

        public UserInfo UserInfo { get; set; }

        public IList<DrunkDrinks> DrunkDrinks { get; set; }

        public IList<UserAchievements> UserAchievements { get; set; }   
    }
}