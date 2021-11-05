using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using megaDesk_Web.Models;

namespace megaDesk_Web.Pages.Quotes
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public EditModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
                .Include(d => d.Delivery)
                .Include(d => d.Desk).FirstOrDefaultAsync(m => m.DeskQuoteID == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
           ViewData["DeliveryId"] = new SelectList(_context.Set<Delivery>(), "DeliveryId", "deliverySpeed");
           ViewData["DeskId"] = new SelectList(_context.Set<Desk>(), "DeskId", "DeskId");
           ViewData["DesktopMaterialId"] = new SelectList(_context.Set<DesktopMaterial>(), "DesktopMaterialId", "MaterialName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DeskQuote.Price = DeskQuote.calcPrice(_context);
            // _context.DeskQuote.Add(DeskQuote);
            _context.Attach(DeskQuote).State = EntityState.Modified;
            // await _context.SaveChangesAsync();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.DeskQuoteID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.DeskQuoteID == id);
        }
    }
}
