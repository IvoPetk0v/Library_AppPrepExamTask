using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        public Task<ICollection<AllBookViewModel>> GetAllBookAsync();
        public Task<ICollection<AllBookViewModel>> GetMineBooksAsync(string userId);
        public Task<AddBookViewModel> GetAddBookModelAsync();
        public Task AddBookAsync(AddBookViewModel model);
        public Task AddToCollection(BookViewModel model,string userId);
        public Task<BookViewModel?> GetBookByIdAsync(int id);
        public Task RemoveFromCollection(string id, BookViewModel model);
    }
}
