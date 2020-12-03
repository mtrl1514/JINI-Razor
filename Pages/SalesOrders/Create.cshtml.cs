using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JINI.Data;
using JINI.Models;

namespace JINI.Pages.SalesOrders
{
    public class CreateModel : CustomerNamePageModel
    {
        private readonly JINI.Data.JINIContext _context;

        public CreateModel(JINI.Data.JINIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCustomersDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public SalesOrder SalesOrder { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SalesOrders.Add(SalesOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");


            var emptySalesOrder = new SalesOrder();

            if (await TryUpdateModelAsync<SalesOrder>(
                 emptySalesOrder,
                 "salesorder",   // Prefix for form value.
                 s => s.SalesOrderNo, s => s.SalesDate, s => s.Customer))
            {
                _context.SalesOrders.Add(emptySalesOrder);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateCustomersDropDownList(_context, emptySalesOrder.Customer);
            return Page();

        }
    }
}
