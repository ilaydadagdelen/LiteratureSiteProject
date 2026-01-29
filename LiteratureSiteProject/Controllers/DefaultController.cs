using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IFeatureService _featureService;

        public DefaultController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IActionResult Index()
        {
            var values = _featureService.TGetList();
            return View(values);
        }
    }
}
