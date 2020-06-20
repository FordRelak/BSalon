using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BSalonWebApp.Pages
{
    public class RecordModel : PageModel
    {
        public IActionResult OnGet(int? id)
        {
            if (id is null)
            {
                return Redirect(Url.Page("OnlineRecords"));
            }
            return Page();
        }
    }
}