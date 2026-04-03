using Microsoft.AspNetCore.Mvc;

namespace loginpageusingmvc.Controllers
{
    [Route("Dashboard")]
    public class DashboradController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
