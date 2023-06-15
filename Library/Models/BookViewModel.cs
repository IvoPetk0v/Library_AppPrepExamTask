using System.ComponentModel.DataAnnotations;
using static Library.Common.DataModelConstants;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(BookRatingMinValue, BookRatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; } 

    }
}
