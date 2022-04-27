using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.MVC.Controllers
{
    public class AgencyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
