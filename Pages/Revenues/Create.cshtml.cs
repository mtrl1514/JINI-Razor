using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JINI.Data;
using JINI.Models;

namespace JINI.Pages.Revenues
{
    public class CreateModel : PageModel
    {
        private readonly JINI.Data.JINIContext _context;

        public CreateModel(JINI.Data.JINIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Revenue Revenue { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Revenues.Add(Revenue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
