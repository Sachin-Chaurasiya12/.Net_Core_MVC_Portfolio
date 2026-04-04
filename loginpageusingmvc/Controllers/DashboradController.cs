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
            return View();
        }
    }
}
