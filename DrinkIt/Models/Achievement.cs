using System.ComponentModel.DataAnnotations;

namespace DrinkIt.Models
{
    public class Achievement
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }
    }
}