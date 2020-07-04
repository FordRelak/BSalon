using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BSalonWebApp.Data;
using BSalonWebApp.Models;
using BSalonWebApp.Models.SalonServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BSalonWebApp.Pages
{
    public class DailyScheduleModel : PageModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required]
        public Record Record { get; set; }

        [BindProperty(SupportsGet = true)]
        public Service Service { get; set; }

        public DateTime DateTime { get; set; }

        public WorkDay WorkDay { get; set; }

        private readonly BSalonDbContext _context;
        public DailyScheduleModel(BSalonDbContext context) =>
            _context = context;

        public IActionResult OnGet(string title, string year, string month, string day)
        {
            if (title == null || year == null || month == null || day == null)
                return RedirectToPage("OnlineRecords");

            if (!CheckAll(title, year, month, day))
                return RedirectToPage("OnlineRecords");

            WorkDay = new WorkDay(_context.Records.ToList(), DateTime);

            return Page();
        }

        public async Task<IActionResult> OnPostAddRecordAsync(string title, string year, string month, string day)
        {
            if (!ModelState.IsValid)
            {
                if (title == null || year == null || month == null || day == null)
                    return RedirectToPage("OnlineRecords");

                if (!CheckAll(title, year, month, day))
                    return RedirectToPage("OnlineRecords");

                if (IfTimeIsIndicated())
                    ViewData["ErrorTime"] = "Время не указано";

                WorkDay = new WorkDay(_context.Records.ToList(), DateTime);

                return Page();
            }

            if (IfTimeIsIndicated())
            {
                ViewData["ErrorTime"] = "Время не указано";

                WorkDay = new WorkDay(_context.Records.ToList(), DateTime);

                return Page();
            }

            Record.IsFree = false;
            Record.ServiceID = Service.Id;

            _context.Records.Add(Record);
            await _context.SaveChangesAsync();

            return RedirectToPage("OnlineRecords");
        }

        /// <summary>
        /// Указал ли пользователь время при заполнении формы
        /// </summary>
        /// <returns>true - время указано; false - дата не указано</returns>
        private bool IfTimeIsIndicated() =>
            Record.Time.Year == 1;



        private bool CheckAll(string title, string year, string month, string day) =>
            TryParseTitle(title) && CheckDataDate(year, month, day) && TryParseDate();

        private bool TryParseTitle(string title)
        {
            var service = _context.Services.First(s => s.Title == title);
            if (service is null)
                return false;
            else
                Service = service;
            return true;
        }

        private bool CheckDataDate(string year, string month, string day)
        {
            int _year, _month, _day;
            if (int.TryParse(year, out _year) && int.TryParse(month, out _month) && int.TryParse(day, out _day))
            {
                if (_year > 0 && _month > 0 && _day > 0)
                {
                    Year = _year;
                    Month = _month;
                    Day = _day;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private bool TryParseDate()
        {
            DateTime = new DateTime(Year, Month, Day);
            if (DateTime.Date >= DateTime.Now.Date)
                return true;
            else
                return false;
        }

    }
}