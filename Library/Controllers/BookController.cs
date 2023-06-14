using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var model=await bookService.GetAllBookAsync();
            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await bookService.GetMineBooksAsync(GetUserId());
            return View(model);
        }

    }
}
