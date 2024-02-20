using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Fuge.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Movie category is required.")]
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage="Movie title is required.")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage="Please enter a valid year.")]
        [Range(1888, Int32.MaxValue, ErrorMessage ="Year must be greater than 1888.")]
        public int Year { get; set; } = 1888;

        public string? Director { get; set; } = "";

        [Required(ErrorMessage="Please enter a rating.")]
        public string? Rating { get; set; } = "";
        [Required]
        public bool CopiedToPlex { get; set; }

        public bool Edited { get; set; }
        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; }

    }
}
