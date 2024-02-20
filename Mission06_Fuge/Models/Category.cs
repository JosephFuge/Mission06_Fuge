using System.ComponentModel.DataAnnotations;

namespace Mission06_Fuge.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Category { get; set; } = "";
    }
}
