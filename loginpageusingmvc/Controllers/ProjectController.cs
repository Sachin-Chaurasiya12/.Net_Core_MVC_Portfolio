using loginpageusingmvc.Data;
using loginpageusingmvc.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace loginpageusingmvc.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;
        public ProjectController(AppDbContext context) {
            _context = context; 
        }

        public IActionResult ProjectIndex()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("login", "Account");
            }
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                // If session exists but user is deleted from DB, clear session and kick them out
                HttpContext.Session.Clear();
                return RedirectToAction("login", "Account");
            }
            ViewBag.Role = user.Role;
            return View();
        }
        [HttpGet]
        public IActionResult ProjectEdit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var id = HttpContext.Session.GetInt32("UserId");
            if (id == null)
            {
                return View(new Models.Project());
            }
            else
            {
                return View(_context.UserProjects.Find(id));
            }
        }

        [HttpPost]
        //public async Task<IActionResult> Edit(ProjectModeldto dto, IFormFile image) {
        //    var userId = HttpContext.Session.GetInt32("UserId");
        //    if (userId == null)
        //    {
        //        return RedirectToAction("login", "Account");
        //    }



    }
}
