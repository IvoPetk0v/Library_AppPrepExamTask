using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        
        public string CollectorId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(CollectorId))]
        public virtual IdentityUser Collector { get; set; } = null!;

      
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; } = null!;

      
    }
}
