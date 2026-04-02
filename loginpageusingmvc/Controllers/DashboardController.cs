using loginpageusingmvc.Data;
using loginpageusingmvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Linq;

namespace loginpageusingmvc.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }


        // GET: Show Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Handle Login
        [HttpPost]
        public IActionResult Login([FromBody]UserLogin model)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == model.Username
                                  && u.Password == model.Password);

            if (user != null)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Registerform()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            if (_context.Users.Any(u => u.Username == model.UserName))
            {
                return Json(new { success = false, message= "Users already Exist"});
            }

            var newUser = new UserLogin
            {
                Name = model.Name,
                Username = model.UserName,
                Password = model.Password
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Json(new { success = true });
        }
        // Dashboard page after login
        public IActionResult Index()
        {
            return View();
        }
    }
}