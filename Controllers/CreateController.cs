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

                        bool isEmptyRow = Enumerable.Range(1, 9) // колонки 1–9
                        .All(col => string.IsNullOrWhiteSpace(worksheet.Cells[row, col].Text));

                        if (isEmptyRow)
                        {
                            // Повністю порожній рядок — ігноруємо, без помилок
                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(phoneNumber))
                        {
                            errors.Add($"Рядок {row}: відсутній номер телефону.");
                            continue;
                        }

                        // Перевірка на наявність у базі
                        bool exists = _context.PersonalRecords.Any(p => p.PhoneNumber == phoneNumber);
                        if (exists)
                        {
                            continue;
                        }

                        // Зчитування інших даних
                        string lastName = worksheet.Cells[row, 1].Text.Trim();
                        string firstName = worksheet.Cells[row, 2].Text.Trim();
                        string soname = worksheet.Cells[row, 3].Text.Trim();
                        string rank = worksheet.Cells[row, 6].Text.Trim();
                        string numberOrg = worksheet.Cells[row, 7].Text.Trim();
                        string education = worksheet.Cells[row, 8].Text.Trim();

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


    }
}