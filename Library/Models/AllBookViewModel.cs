using System.ComponentModel.DataAnnotations;

using static Library.Common.DataModelConstants;

namespace Library.Models
{
    public class AllBookViewModel
    {

        public int Id { get; set; }

        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength)]
        public string Author { get; set; } = null!;


        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Range(BookRatingMinValue, BookRatingMaxValue)]
        public decimal Rating { get; set; }

        public string Category { get; set; } = null!;


    }
}
