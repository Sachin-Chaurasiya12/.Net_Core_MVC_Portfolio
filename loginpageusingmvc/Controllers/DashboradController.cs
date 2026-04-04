using loginpageusingmvc.Data;
using loginpageusingmvc.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace loginpageusingmvc.Controllers
{
    [Route("Dashboard")]
    public class DashboradController : Controller
    {
        private readonly AppDbContext _context;
        public DashboradController(AppDbContext context) {
            _context = context;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("login","Account");
            }
            var user = _context.Users.Find(userId.Value);
            return View(user);
        }
        [HttpGet("EditProfile")]
        public IActionResult EditProfile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var user = _context.Users.Find(userId.Value);
            return View(user);
        }
    }
}
