using loginpageusingmvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace loginpageusingmvc.Controllers
{
    [Route("Projects")]
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;
        public ProjectController(AppDbContext context) {
            _context = context; 
        }

        [HttpGet("projectIndex")]
        public IActionResult ProjectIndex()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            string? role = "";

            if (userId != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                role = user?.Role;
            }

            ViewBag.Role = role;
            var projects = _context.UserProjects.ToList();

            return View(projects);
        }
    }
}
