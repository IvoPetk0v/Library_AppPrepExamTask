using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
