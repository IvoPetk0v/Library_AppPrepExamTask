using System.ComponentModel.DataAnnotations;
using static Library.Common.DataModelConstants;

namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; }
       
    }
}
