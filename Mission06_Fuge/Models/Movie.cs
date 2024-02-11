using System.ComponentModel.DataAnnotations;

namespace Mission06_Fuge.Models
{
    public class Movie
    {
        [Required]
        public int MovieId { get; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Movie category is required.")]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Movie title is required.")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Movie year is required.")]
        public string Year { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Movie director is required.")]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }

    }
}
