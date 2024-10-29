using Microsoft.AspNetCore.Mvc;
using PersonalRecords.Data;
using PersonalRecords.Models;

namespace PersonalRecords.Controllers
{
    public class CreateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreateController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(PersonalRecord personalRecord)
        {
            if (!ModelState.IsValid)
            {
                return View(personalRecord); 
            }
            _context.PersonalRecords.Add(personalRecord);
            _context.SaveChanges();
            ViewBag.Message = "Запис додано";
            return RedirectToAction("Index");
        }
    }
}
