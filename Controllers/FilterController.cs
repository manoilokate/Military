using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PersonalRecords.Data;
using PersonalRecords.Models;

namespace PersonalRecords.Controllers
{
    public class FilterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(PersonalRecord filter)
        {
            var filteredPeople = _context.PersonalRecords.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Rank))
            {
                filteredPeople = filteredPeople.Where(p => p.Rank.Contains(filter.Rank));
            }

            if (!string.IsNullOrEmpty(filter.NumberOrganization))
            {
                filteredPeople = filteredPeople.Where(p => p.NumberOrganization.Contains(filter.NumberOrganization));
            }

            if (!string.IsNullOrEmpty(filter.Education))
            {
                filteredPeople = filteredPeople.Where(p => p.Education == filter.Education);
            }

            var result = filteredPeople.ToList();
            return View("Index", result);
        }
    }
}
