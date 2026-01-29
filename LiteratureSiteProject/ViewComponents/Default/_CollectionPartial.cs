using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.ViewComponents.Default
{
    public class _CollectionPartial : ViewComponent
    {
        private readonly IBookService _bookService;

        public _CollectionPartial(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _bookService.TGetList();
            return View(values);
        }
    }
}
