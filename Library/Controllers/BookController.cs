using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Library.Models;
using Library.Services.Interfaces;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        private string GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }

        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllBookAsync();
            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await bookService.GetMineBooksAsync(GetUserId());
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await bookService.GetAddBookModelAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await bookService.AddBookAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var userId = GetUserId();
            var book = await bookService.GetBookByIdAsync(id);
            await bookService.AddToCollection(book, userId);
            return RedirectToAction("All", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = GetUserId();
            var book = await bookService.GetBookByIdAsync(id);
            await bookService.RemoveFromCollection(userId, book);

            return RedirectToAction("Mine","Book");
        }
    }
}
