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
    public class DetailsModel : PageModel
    {
        private readonly JINI.Data.JINIContext _context;

        public DetailsModel(JINI.Data.JINIContext context)
        {
            _context = context;
        }

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
    }
}
