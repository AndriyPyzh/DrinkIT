using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkIt.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}