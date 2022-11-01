using Microsoft.AspNetCore.Mvc;

namespace B.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
