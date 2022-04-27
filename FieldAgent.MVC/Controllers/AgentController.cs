using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.MVC.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
