using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using PersonalRecords.Data;
using PersonalRecords.Models;
using System.Diagnostics;
using System.Globalization;

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
        public async Task<IActionResult> Index(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                TempData["Message"] = "Файл не вибрано.";
                return RedirectToAction("Index");
            }

            try
            {
                var records = new List<PersonalRecord>();
                var errors = new List<string>();

                using var stream = new MemoryStream();
                await excelFile.CopyToAsync(stream);
                stream.Position = 0;

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage(stream);
                var worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        string phoneNumber = worksheet.Cells[row, 9].Text.Trim();

                        bool isEmptyRow = Enumerable.Range(1, 9) 
                        .All(col => string.IsNullOrWhiteSpace(worksheet.Cells[row, col].Text));

                        if (isEmptyRow)
                        {
                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(phoneNumber))
                        {
                            errors.Add($"Рядок {row}: відсутній номер телефону.");
                            continue;
                        }

                        bool exists = _context.PersonalRecords.Any(p => p.PhoneNumber == phoneNumber);
                        if (exists)
                        {
                            continue;
                        }

                        string lastName = CleanString(worksheet.Cells[row, 1].Text);
                        string firstName = CleanString(worksheet.Cells[row, 2].Text);
                        string soname = CleanString(worksheet.Cells[row, 3].Text);
                        string rank = CleanString(worksheet.Cells[row, 6].Text);
                        string numberOrg = CleanString(worksheet.Cells[row, 7].Text);
                        string education = CleanString(worksheet.Cells[row, 8].Text);

                        if (!DateTime.TryParse(worksheet.Cells[row, 4].Text.Trim(), out DateTime dob))
                        {
                            errors.Add($"Рядок {row}: неправильна дата народження.");
                            continue;
                        }

                        if (!DateTime.TryParse(worksheet.Cells[row, 5].Text.Trim(), out DateTime startWork))
                        {
                            errors.Add($"Рядок {row}: неправильна дата початку роботи.");
                            continue;
                        }

                        var record = new PersonalRecord
                        {
                            LastName = lastName,
                            FirstName = firstName,
                            Soname = soname,
                            DateOfBirth = DateOnly.FromDateTime(dob),
                            DateOfStartWork = DateOnly.FromDateTime(startWork),
                            Rank = rank,
                            NumberOrganization = numberOrg,
                            Education = education,
                            PhoneNumber = phoneNumber
                        };
                        records.Add(record);
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Рядок {row}: помилка обробки - {ex.Message}");
                    }
                }
                if (records.Any())
                {
                    _context.PersonalRecords.AddRange(records);
                    await _context.SaveChangesAsync();
                }

                TempData["Message"] = $"Успішно додано {records.Count} запис(ів). ";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Помилка при зчитуванні Excel: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        private static string CleanString(string? input)
        {
            return string.IsNullOrWhiteSpace(input)
                ? string.Empty
                : new string(input
                    .Where(c => !char.IsControl(c)) // видалити control-символи
                    .ToArray())
                    .Trim(); // обрізає пробіли
        }
    }
}