using Humanizer;
using loginpageusingmvc.Data;
using loginpageusingmvc.DTOs;
using loginpageusingmvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Linq;

namespace loginpageusingmvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
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
        public IActionResult Login([FromBody]UserReadDTO model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == model.Email);

            if (user != null)
            {
                if (user.Password.Equals(model.Password)){
                    return Json(new { success = true });
                }
            }
            if (model == null)
            {
                return Json(new { success = false, message = "Model is null" });
            }

            return Json(new { success = false ,message="User does'nt exist"});
        }
        [HttpGet]
        public IActionResult Registerform()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register([FromBody] UserCreateDto model)
        {
            if (_context.Users.Any(u => u.Username == model.Email))
            {
                return Json(new { success = false, message= "Users already Exist"});
            }

            var newUser = new UserLogin
            {   
                Name = model.Name,
                Username = model.Email,
                Password = model.Password,
                Dob = model.Dob,
                phonenumber = model.Phonenumber
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