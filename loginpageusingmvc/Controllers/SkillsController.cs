using loginpageusingmvc.Data;
using loginpageusingmvc.DTOs;
using loginpageusingmvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace loginpageusingmvc.Controllers
{
    public class SkillsController : Controller
    {
        private readonly AppDbContext _context;
        public SkillsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Skillspage()
        {
            var userid = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.Find(userid);
            if (userid == null || user == null)
            {
                return RedirectToAction("login", "Account");
            }
            ViewBag.Role = user.Role;

            var skill = _context.Skills.ToList();

            var model = skill.Select(s => new SkillsReadDTO
            {
                Title = s.Title,
                Percentage = s.Percentage,
                Category = s.Category,
            }).ToList();
            return View(model);
        }

        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public IActionResult SkillsAdd(){
            return View(); 
        }
        [HttpPost]
        public IActionResult AddSkills(SkillCreateDTO dto)
        {
            Boolean done = false;
            var userid = HttpContext.Session.GetInt32("UserId");

            if (userid == null)
            {
                return RedirectToAction("login", "Account");
            }
            if (ModelState.IsValid)
            {

                var skill = new Skills
                {
                    Title = dto.Title,
                    Percentage = dto.Percentage,
                    Category = dto.Category,
                    userid = (int)userid
                };
                _context.Skills.Add(skill);
                _context.SaveChanges();
                done = true;
            }
            if (done)
            {
                ViewBag.display = "1 skill added";
            }
            return View("SkillsAdd", dto);
        }
    }
}
