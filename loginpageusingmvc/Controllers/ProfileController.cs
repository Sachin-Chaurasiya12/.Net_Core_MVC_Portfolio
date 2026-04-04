using loginpageusingmvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace loginpageusingmvc.Controllers
{
    [Route("Profile")]
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;
        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(string name, IFormFile file)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("login");
            }
            var user = _context.Users.Find(userId);

            user.Name = name;

            // 1. Get the uploaded file data
            if (file != null && file.Length > 0)
            {
                // 2. Generate a unique name so images don't overwrite each other
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // 3. Define the DESTINATION (The server's 'uploads' folder)
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                // 4. Create the 'uploads' folder if it doesn't exist yet
                var folder = Path.GetDirectoryName(uploadPath);
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                // 5. Physically save the file data from the user's computer to the server's folder
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // 6. Update the Database string so the website knows where to look
                user.ProfileImagePath = "/uploads/" + fileName;
            }
            else if (string.IsNullOrEmpty(user.ProfileImagePath))
            {
                // 7. DEFAULT: If no file was uploaded and there's no existing path, use the default
                user.ProfileImagePath = "/uploads/Default-welcomer.png";
            }
            _context.SaveChanges();

            return RedirectToAction("index","Dashboard");
        }

    }
}
