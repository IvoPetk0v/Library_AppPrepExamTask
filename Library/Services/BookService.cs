using Library.Data;
using Library.Models;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<AllBookViewModel>> GetAllBookAsync()
        {
            return await this.dbContext.Books.Select(b => new AllBookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                ImageUrl = b.ImageUrl,
                Category = b.Category.Name
            }).ToArrayAsync();
        }

        public async Task<ICollection<AllBookViewModel>> GetMineBooksAsync(string userId)
        {
            return await this.dbContext.IdentityUsersBooks.Where(ub => ub.CollectorId == userId).Select(b => new AllBookViewModel()
            {
                Id = b.Book.Id,
                Title = b.Book.Title,
                Author = b.Book.Author,
                Description = b.Book.Description,
                ImageUrl = b.Book.ImageUrl,
                Category = b.Book.Category.Name
            }).ToArrayAsync();
        }
    }
}
