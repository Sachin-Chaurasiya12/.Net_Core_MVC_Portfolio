using Microsoft.AspNetCore.Mvc;

namespace loginpageusingmvc.Controllers
{
    public class SkillsController : Controller
    {
        public IActionResult Skillspage()
        {
            return View();
        }
    }
}
