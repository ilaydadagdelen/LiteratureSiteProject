using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.Controllers
{
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager(new EfBookDal());

        public IActionResult Index()
        {
            var values = bookManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult BookDetails(int id)
        {
            var values = bookManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult BookDetails(Book p)
        {
            return View();
        }

    }
}
