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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View("~/Views/Create/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Index(string LastName, string FirstName, string Soname, string action)
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
                switch (action)
                {
                    case "Contacts":
                        var contacts = _context.FamilyContacts
                            .Where(c => c.PersonalRecordId == matchedRecord.Id)
                            .ToList();
                        ViewBag.Title = "Контактна інформація";
                        ViewBag.Data = contacts;  
                        break;

                    case "SickLeaves":
                        var sickLeaves = _context.InformationAboutDiseases
                            .Where(c => c.PersonalRecordId == matchedRecord.Id)
                            .ToList();
                        ViewBag.Title = "Інформація про лікарняні ";
                        ViewBag.Data = sickLeaves;  
                        break;

                    case "Vacations":
                        var vacations = _context.InformationAboutVacation
                            .Where(c => c.PersonalRecordId == matchedRecord.Id)
                            .ToList();
                        ViewBag.Title = "Інформація про відпустки";
                        ViewBag.Data = vacations;  
                        break;

                    case "Trainings":
                        var trainings = _context.AdditionalTraining
                            .Where(c => c.PersonalRecordId == matchedRecord.Id)
                            .ToList();
                        ViewBag.Title = "Інформація про навчання";
                        ViewBag.Data = trainings;  
                        break;

                    default:
                        ViewBag.ErrorMessage = "Невідома дія";
                        return View(matchedRecord);
                }

                return View(matchedRecord);
            }
            else
            {
                ViewBag.Message = "Запис не знайдено !";
                return View();
            }
        }

    }
}
