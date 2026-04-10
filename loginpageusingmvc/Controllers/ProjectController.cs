using loginpageusingmvc.Data;
using loginpageusingmvc.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var allProjects = _context.UserProjects.ToList();
            return View(allProjects);
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public IActionResult ProjectEdit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectModeldto model, IFormFile image)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("login", "Account");
            }

            // Look for existing project
            var existingProject = await _context.UserProjects.FindAsync(model.ProjectId);

            if (existingProject == null || model.ProjectId == 0)
            {
                // --- CREATE MODE ---
                var newProject = new Models.Project
                {
                    Title = model.Title,
                    Description = model.Description,
                    GithubUrl = model.GithubUrl,
                    UserId = (int)userId
                };

                if (image != null)
                {
                    newProject.ImagePath = await SaveFile(image);
                }

                _context.UserProjects.Add(newProject);
            }

            // Only one save call needed at the end
            await _context.SaveChangesAsync();
            return RedirectToAction("ProjectIndex");
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            // Create a unique filename so images don't overwrite each other
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Set the path to the wwwroot/uploads folder
            string uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            // Ensure the directory exists
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

            string filePath = Path.Combine(uploads, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName; // Return just the name to save in the database
        }

    }
}
