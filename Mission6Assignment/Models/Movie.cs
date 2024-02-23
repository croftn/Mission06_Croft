using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Croft.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int ? CategoryId { get; set; }
        public Category ? Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage ="Year must be greater than or equal to 1888")]
        public int Year { get; set; }


        public string ? Director { get; set; }

        public string ? Rating { get; set; }

        [Required(ErrorMessage ="Edited status is required")]
        public bool  Edited { get; set; }

        public string ? LentTo { get; set; }

        [Required(ErrorMessage = "Copied to Plex status is required")]
        public int CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string ? Notes { get; set; }
    }
}
