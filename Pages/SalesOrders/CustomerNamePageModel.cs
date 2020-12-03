using JINI.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JINI.Pages.SalesOrders
{
    public class CustomerNamePageModel : PageModel
    {
        public SelectList CustomerNameSL { get; set; }

        public void PopulateCustomersDropDownList(JINIContext _context,
            object selectedCustomer = null)
        {
            var customersQuery = from d in _context.Customers
                                   orderby d.Name // Sort by name.
                                   select d;

            CustomerNameSL = new SelectList(customersQuery.AsNoTracking(),
                        "ID", "Name", selectedCustomer);
        }
    }
}
