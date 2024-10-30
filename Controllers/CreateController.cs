using Microsoft.AspNetCore.Mvc;
using PersonalRecords.Data;
using PersonalRecords.Models;
using System.Diagnostics;

namespace PersonalRecords.Controllers
{
    public class CreateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreateController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(PersonalRecord personalRecord)
        {
            
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                           Debug.WriteLine($"Помилка: {error.ErrorMessage}");
                    }
                }
                return View(personalRecord);
            }

            await _context.PersonalRecords.AddAsync(personalRecord);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Запис успішно додано!";
            return RedirectToAction("Index");
        }

    }
}
