using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JINI.Data;
using JINI.Models;

namespace JINI.Pages.SalesOrderItems
{
    public class DeleteModel : PageModel
    {
        private readonly JINI.Data.JINIContext _context;

        public DeleteModel(JINI.Data.JINIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesOrderItem SalesOrderItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOrderItem = await _context.SalesOrderItems.FirstOrDefaultAsync(m => m.ID == id);

            if (SalesOrderItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOrderItem = await _context.SalesOrderItems.FindAsync(id);

            if (SalesOrderItem != null)
            {
                _context.SalesOrderItems.Remove(SalesOrderItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
