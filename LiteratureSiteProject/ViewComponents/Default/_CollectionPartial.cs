using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.ViewComponents.Default
{
    public class _CollectionPartial : ViewComponent
    {
        BookManager bookManager = new BookManager(new EfBookDal());

        public IViewComponentResult Invoke()
        {
            var values = bookManager.TGetList();
            return View(values);
        }
    }
}
