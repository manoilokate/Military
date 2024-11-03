using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalRecords.Data;
using PersonalRecords.Models;
using System.ComponentModel.DataAnnotations;

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
            PersonalRecord? matchedRecord = null;
            bool isSearchPerformed = false;

            if (!string.IsNullOrEmpty(LastName) || !string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(Soname))
            {
                isSearchPerformed = true;

                matchedRecord = _context.PersonalRecords
                    .FirstOrDefault(p =>
                        (string.IsNullOrEmpty(LastName) || p.LastName == LastName) &&
                        (string.IsNullOrEmpty(FirstName) || p.FirstName == FirstName) &&
                        (string.IsNullOrEmpty(Soname) || p.Soname == Soname));
            }

            ViewBag.IsSearchPerformed = isSearchPerformed;

            if (matchedRecord != null)
            {
                return View("Index", matchedRecord);
            }
            else
            {
                ViewBag.Message = "Запис не знайдено";
                return View("Index");
            }
        }
    }
}
