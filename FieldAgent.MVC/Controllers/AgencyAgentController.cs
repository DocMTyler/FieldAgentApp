using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.MVC.Controllers
{
    public class AgencyAgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
