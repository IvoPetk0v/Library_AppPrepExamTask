using Library.Data;
using Library.Data.Models;
using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                Category = b.Category.Name,
                Rating = b.Rating
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

        public async Task<AddBookViewModel> GetAddBookModelAsync()
        {
            var categories = await dbContext.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToArrayAsync();
            var model = new AddBookViewModel()
            {
                Categories = categories
            };
            return model;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.Url,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

        }

        public async Task AddToCollection(BookViewModel model, string userId)
        {
            bool isAdded = dbContext
                .IdentityUsersBooks
                .Any(ub => ub.Book.Id == model.Id && ub.CollectorId == userId);

            if (isAdded == false)
            {
                await dbContext.IdentityUsersBooks
                     .AddAsync(new IdentityUserBook()
                     {
                         CollectorId = userId,
                         BookId = model.Id
                     });
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext.Books.Where(b => b.Id == id).Select(b => new BookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating,
                CategoryId = b.CategoryId

            }).FirstOrDefaultAsync();
        }

        public async Task RemoveFromCollection(string id, BookViewModel model)
        {
            var userBook = await dbContext
                .IdentityUsersBooks
                .Where(ub => ub.CollectorId == id && ub.BookId == model.Id)
                .FirstOrDefaultAsync();

            if (userBook != null)
            {
                dbContext.IdentityUsersBooks.Remove(userBook);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
