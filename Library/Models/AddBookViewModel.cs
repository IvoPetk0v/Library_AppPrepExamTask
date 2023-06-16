using System.ComponentModel.DataAnnotations;

using static Library.Common.DataModelConstants;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength)]
        public string Author { get; set; } = null!;


        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string Url { get; set; } = null!;

        [Range(BookRatingMinValue, BookRatingMaxValue)] 
        public decimal Rating { get; set; }

        [Range(0,int.MaxValue)]
        public int CategoryId { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
    }
}
