using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using megaDesk_Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace megaDesk_Web.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public IndexModel(MegaDeskWebContext context)
        {
            _context = context;
        }
        public IList<DeskQuote> DeskQuotes { get; set; }
        public SelectList Materials { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedMaterialId { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<DesktopMaterial> bookQuery = from m in _context.DesktopMaterial
                                                    orderby m.MaterialName
                                                    select m;

            var deskQuotes = from m in _context.DeskQuote
                            .Include(d => d.Delivery)
                            .Include(d => d.Desk.DesktopMaterial)
                             select m;

            if (!string.IsNullOrEmpty(SelectedMaterialId))
            {
                deskQuotes = deskQuotes
                .Where(x => x.Desk.DesktopMaterialId == Int32.Parse(SelectedMaterialId));
            }


            Materials = new SelectList(await bookQuery.Distinct().ToListAsync(), "DesktopMaterialId", "MaterialName");
            DeskQuotes = await deskQuotes.ToListAsync();
        }
    }
}
