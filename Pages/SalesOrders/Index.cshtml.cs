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
    public class IndexModel : PageModel
    {
        private readonly JINI.Data.JINIContext _context;

        public IndexModel(JINI.Data.JINIContext context)
        {
            _context = context;
        }

        public IList<SalesOrder> SalesOrder { get;set; }

        public async Task OnGetAsync()
        {
            SalesOrder = await _context.SalesOrders.ToListAsync();
        }
    }
}
