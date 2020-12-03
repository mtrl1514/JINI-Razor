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
    public class IndexModel : PageModel
    {
        private readonly JINI.Data.JINIContext _context;

        public IndexModel(JINI.Data.JINIContext context)
        {
            _context = context;
        }

        public IList<SalesOrderItem> SalesOrderItem { get;set; }

        public async Task OnGetAsync()
        {            
            SalesOrderItem = await _context.SalesOrderItems
                .Include(c => c.SalesOrder)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
