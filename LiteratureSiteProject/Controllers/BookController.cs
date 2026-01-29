using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var values = _bookService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult BookDetails(int id)
        {
            var values = _bookService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult BookDetails(Book p)
        {
            return View();
        }

    }
}
