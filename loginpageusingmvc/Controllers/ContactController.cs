using Microsoft.AspNetCore.Mvc;

namespace loginpageusingmvc.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult ContactPage()
        {
            return View();
        }
    }
}
