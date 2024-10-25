using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalRecords.Data;
using PersonalRecords.Models;

namespace PersonalRecords.Controllers
{
    public class SearchController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string LastName, string FirstName, string Soname)
        {
            List<PersonalRecord> matchedRecords = new List<PersonalRecord>();
            bool isSearchPerformed = false; 

            if (!string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(Soname))
            {
                isSearchPerformed = true;

                matchedRecords = _context.PersonalRecords
                    .Where(p =>
                        (string.IsNullOrEmpty(LastName) || p.LastName == LastName) &&
                        (string.IsNullOrEmpty(FirstName) || p.FirstName == FirstName) &&
                        (string.IsNullOrEmpty(Soname) || p.Soname == Soname))
                    .ToList();
            }

            ViewBag.IsSearchPerformed = isSearchPerformed; 
            if (matchedRecords.Any())
            {
                return View("Index", matchedRecords);
            }
            else
            {
                ViewBag.Message = "Запис не знайдено";
                return View("Index"); 
            }
        }
    }
}
