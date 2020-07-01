using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSalonWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BSalonWebApp.Pages.Shared
{
    public class AddRecordFormPartialModel : PageModel
    {
        private readonly BSalonDbContext _context;
        public AddRecordFormPartialModel(BSalonDbContext context)=>
            _context=context;

        public void OnGet()
        {

        }
    }
}