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
        public async Task<IActionResult> Index(PersonalRecord model, string action)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Введені дані некоректні";
                return View(model);
            }

            if (string.IsNullOrEmpty(action))
            {
                // Обробка звичайного пошуку
                TempData["Message"] = "Пошук виконано успішно!";
                ViewBag.IsSearchPerformed = true;
                return View(model);
            }

            // Виконання додаткових дій
            switch (action)
            {
                case "Contacts":
                    var contacts = _context.FamilyContacts
                        .Where(c => c.PersonalRecord.LastName == model.LastName && c.PersonalRecord.FirstName == model.FirstName)
                        .ToList();
                    ViewBag.Title = "Контактна інформація";
                    ViewBag.Data = contacts.Select(c => $"Ким доводиться: {c.Relationship}, Телефон: {c.PhoneNumber}, " +
                        $"Email: {c.Email}, Адреса: {c.Address}");
                    break;

                case "SickLeaves":
                    var sickLeaves = _context.InformationAboutDiseases
                        .Where(c => c.PersonalRecord.LastName == model.LastName && c.PersonalRecord.FirstName == model.FirstName)
                        .ToList();
                    ViewBag.Title = "Інформація про лікарняні";
                    ViewBag.Data = sickLeaves.Select(c => $"Початок: {c.StartedToIll}, Кінець: {c.FinishedToIll}, " +
                        $"Загальна к-сть днів: {c.IllnessDurationDays}, Перебував(-ла) в лікарні: {c.StayInHospital}");
                    break;

                case "Vacations":
                    var vacations = _context.InformationAboutVacation
                        .Where(c => c.PersonalRecord.LastName == model.LastName && c.PersonalRecord.FirstName == model.FirstName)
                        .ToList();
                    ViewBag.Title = "Інформація про відпустки";
                    ViewBag.Data = vacations.Select(c => $"Початок: {c.StartedVacation}, Кінець: {c.FinishedVacation}, " +
                        $"Загальна к-сть днів: {c.VacationDurationDays}, Оплачувана відпустка: {c.IsPaidVacation}");
                    break;

                case "Trainings":
                    var trainings = _context.AdditionalTraining
                        .Where(c => c.PersonalRecord.LastName == model.LastName && c.PersonalRecord.FirstName == model.FirstName)
                        .ToList();
                    ViewBag.Title = "Інформація про навчання";
                    ViewBag.Data = trainings.Select(c => $"Назва: {c.TrainingName}, Країна: {c.TrainingCountry}, " +
                        $"Місто: {c.TrainingCity}, Початок: {c.StartedTraining}, Кінець: {c.FinishedTraining}, " +
                        $"Загальна к-сть днів: {c.TrainingDurationDays}");
                    break;

                default:
                    ViewBag.ErrorMessage = "Невідома дія";
                    return View(model);
            }

            ViewBag.IsSearchPerformed = true;
            return View(model);
        }

    }
}
