using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        public Task<ICollection<AllBookViewModel>> GetAllBookAsync();
        public Task<ICollection<AllBookViewModel>> GetMineBooksAsync(string userId);
    }
}
