using Microsoft.AspNetCore.Mvc;

namespace Greeno.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
