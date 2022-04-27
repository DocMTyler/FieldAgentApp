using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.MVC.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
