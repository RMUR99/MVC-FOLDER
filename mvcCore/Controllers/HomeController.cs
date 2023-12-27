using Microsoft.AspNetCore.Mvc;

namespace mvcCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
