using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.MVC.Controllers
{
    public class MissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
