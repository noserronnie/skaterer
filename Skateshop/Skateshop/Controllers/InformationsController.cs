using Microsoft.AspNetCore.Mvc;

namespace Skaterer.Controllers
{
    public class InformationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
