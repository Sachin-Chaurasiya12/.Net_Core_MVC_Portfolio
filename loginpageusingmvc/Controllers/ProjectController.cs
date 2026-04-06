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

            return View();
        }
    }
}
