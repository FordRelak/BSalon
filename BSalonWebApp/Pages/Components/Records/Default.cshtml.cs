using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSalonWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BSalonWebApp.Pages.Components.Records
{
    public class DefaultModel : PageModel
    {
        private readonly BSalonDbContext _context;

        public DefaultModel(BSalonDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
           
        }

        
    }
}