using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JINI.Data;
using JINI.Models;
using Microsoft.EntityFrameworkCore;

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

            var customer = await _context.Customers.FindAsync(SalesOrder.Customer.ID);            
            SalesOrder.Customer = customer;
            
            _context.SalesOrders.Add(SalesOrder);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");                        
        }
    }
}
