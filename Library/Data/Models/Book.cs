using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Common.DataModelConstants;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.UsersBooks = new HashSet<IdentityUserBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(BookAuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required] public string ImageUrl { get; set; } = null!;

        [Required]
        [Precision(4, 2)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<IdentityUserBook> UsersBooks { get; set; }

    }
}
