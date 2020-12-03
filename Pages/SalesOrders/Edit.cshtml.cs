using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JINI.Data;
using JINI.Models;

namespace JINI.Pages.SalesOrders
{
    public class EditModel : CustomerNamePageModel
    {
        private readonly JINI.Data.JINIContext _context;

        public EditModel(JINI.Data.JINIContext context)
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
                .Include(c => c.Customer).FirstOrDefaultAsync(m => m.ID == id);

            if (SalesOrder == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            PopulateCustomersDropDownList(_context, SalesOrder.Customer);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.      
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderToUpdate = await _context.SalesOrders.FindAsync(id);

            if (salesOrderToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<SalesOrder>(
                 salesOrderToUpdate,
                 "course",   // Prefix for form value.
                   c => c.SalesOrderNo, c => c.SalesDate, c => c.Customer))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateCustomersDropDownList(_context, salesOrderToUpdate.Customer);
            return Page();
        }

        private bool SalesOrderExists(int id)
        {
            return _context.SalesOrders.Any(e => e.ID == id);
        }
    }
}
