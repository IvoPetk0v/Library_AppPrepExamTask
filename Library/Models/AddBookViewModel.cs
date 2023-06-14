using System.ComponentModel.DataAnnotations;
using Library.Data.Models;
using static Library.Common.DataModelConstants;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength,
            ErrorMessage = "Title length must be between 10 and 50 characters.")]
        public string Title { get; set; } = null!;

        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength,
            ErrorMessage = "Author length must be between 5 and 50 characters.")]
        public string Author { get; set; } = null!;


        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength,
            ErrorMessage = "Description length must be between 5 and 5000 characters.")]
        public string Description { get; set; } = null!;

        public string Url { get; set; } = null!;

        [Range(BookRatingMinValue, BookRatingMaxValue,
            ErrorMessage = "Rating must be between 0.00 and 10.00")]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }
        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
