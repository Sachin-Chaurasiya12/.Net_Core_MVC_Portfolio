using loginpageusingmvc.Data;
using loginpageusingmvc.DTOs;
using loginpageusingmvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace loginpageusingmvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context) {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactPage()
        {
            var userid = HttpContext.Session.GetInt32("UserId");
            if (userid == null)
            {
                RedirectToAction("login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult ContactForm([FromBody]MessageCreateDTO dto)
        {
            Boolean success = false;
            var userid = HttpContext.Session.GetInt32("UserId");
            if (userid == null)
            {
                RedirectToAction("login", "Account");
            }
            var user = _context.Message.Find(userid);
            if (user == null) {
                var contact = new Contact
                {
                    userid = (int)userid,
                    name = dto.name,
                    email = dto.email,
                    subject = dto.subject,
                    message = dto.message

                };

                _context.Message.Add(contact);
                _context.SaveChanges();

                success = true;
            }
            if (success)
            {
                ViewBag.Show = "Thank you for contacting us";
            }
            return View("ContactPage");
        }
    }
}
