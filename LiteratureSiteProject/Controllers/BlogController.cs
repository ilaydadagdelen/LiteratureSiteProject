using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var values = _blogService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogDetails(int id) 
        {
            ViewBag.i = id;
            var values = _blogService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult BlogDetails(Blog p) 
        {
            return View();
        }
    }
}
