using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.Models
{
    public class UserAchievements
    {
        public int Id { get; set; }
        
        public User User { get; set; }
        
        public Achievement Achievement { get; set; }
    }
}