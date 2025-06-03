using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalRecords.Data;
using PersonalRecords.Models;

namespace PersonalRecords.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register() => View();
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password, string role)
        {
            if (_context.Users.Any(u => u.UserName == username || u.Email == email))
            {
                TempData["ErrorMessage"] = "Юзер вже зареєстрований";
                return View();
            }
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new Users
            {
                UserName = username,
                Email = email,
                Password = hash,
                Role = role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login","Login");
        }
    }
}
