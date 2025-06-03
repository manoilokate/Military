using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PersonalRecords.Data;

namespace PersonalRecords.Controllers
{
    public class LogoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LogoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }
    }
}
