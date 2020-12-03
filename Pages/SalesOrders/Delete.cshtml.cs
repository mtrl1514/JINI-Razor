using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JINI.Data;
using JINI.Models;

namespace JINI.Pages.SalesOrders
{
    public class DeleteModel : PageModel
    {
        private readonly JINI.Data.JINIContext _context;

        public DeleteModel(JINI.Data.JINIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesOrder SalesOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOrder = await _context.SalesOrders
                .AsNoTracking()
                .Include(c => c.Customer)                
                .FirstOrDefaultAsync(m => m.ID == id);

            if (SalesOrder == null)
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

            SalesOrder = await _context.SalesOrders.FindAsync(id);

            if (SalesOrder != null)
            {
                _context.SalesOrders.Remove(SalesOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
