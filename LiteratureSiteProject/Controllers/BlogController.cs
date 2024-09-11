using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IActionResult Index()
        {
            var values = blogManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogDetails(int id) 
        {
            ViewBag.i = id;
            var values = blogManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult BlogDetails(Blog p) 
        {
            return View();
        }
    }
}
