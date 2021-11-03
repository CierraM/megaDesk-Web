using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using megaDesk_Web.Models;

namespace megaDesk_Web.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public IndexModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync()
        {
            DeskQuote = await _context.DeskQuote
                .Include(d => d.Delivery)
                .Include(d => d.Desk).ToListAsync();
        }
    }
}
