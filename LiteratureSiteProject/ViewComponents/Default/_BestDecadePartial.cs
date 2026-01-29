using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.ViewComponents.Default
{
    public class _BestDecadePartial : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BestDecadePartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.TGetList();
            return View(values);
        }
    }
}
