using System.ComponentModel.DataAnnotations;

namespace Mission06_Fuge.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Movie category is required.")]
        public string Category { get; set; } = "";

        public string? SubCategory { get; set; } = "";

        [Required(AllowEmptyStrings = false, ErrorMessage="Movie title is required.")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage="Movie year is required.")]
        public int Year { get; set; } = 2000;

        [Required(AllowEmptyStrings = false, ErrorMessage="Movie director is required.")]
        public string Director { get; set; } = "";

        [Required]
        public string Rating { get; set; } = "";
        public bool Edited { get; set; }
        public string? LentTo { get; set; } = "";

        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; } = "";

    }
}
