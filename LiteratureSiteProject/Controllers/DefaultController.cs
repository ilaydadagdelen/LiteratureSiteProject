using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.Controllers
{
    public class DefaultController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        public IActionResult Index()
        {
            var values = featureManager.TGetList();
            return View(values);
        }
    }
}
