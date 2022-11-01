using Microsoft.AspNetCore.Mvc;

namespace B.Controllers
{
    [Route("About")]
    [ApiVersion("1.0")]
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
