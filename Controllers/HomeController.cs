using Ispit.Books.Models;
using Ispit.Books.Models.Dbo;
using Ispit.Books.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ispit.Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdministracijaService _administracijaService;

        public HomeController(ILogger<HomeController> logger, IAdministracijaService administracijaService)
        {
            _logger = logger;
            _administracijaService = administracijaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Administracija()
        {
            var stranica = await _administracijaService.GetBooks();
            return View(stranica);
        }


        [Authorize]
        
        public IActionResult AddBook()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            
                await _administracijaService.AddBookAsync(book);
                return RedirectToAction("Administracija");
            
        }


        [Authorize]

        public async Task<IActionResult> UpdateBook(int id)

        {
            var book = _administracijaService.GetBook(id);
            return View(book);
        
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book updatedBook)
        {
           
                await _administracijaService.UpdateBookAsync(updatedBook);
            return RedirectToAction("Administracija");

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            await _administracijaService.DeleteBookAsync(bookId);
            return RedirectToAction("Administracija");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
    }
}
