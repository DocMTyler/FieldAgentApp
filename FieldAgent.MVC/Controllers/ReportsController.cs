using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.MVC.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
