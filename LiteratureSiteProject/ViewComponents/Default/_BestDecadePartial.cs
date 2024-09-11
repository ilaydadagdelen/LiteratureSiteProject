using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.ViewComponents.Default
{
    public class _BestDecadePartial : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var values = blogManager.TGetList();
            return View(values);
        }
    }
}
