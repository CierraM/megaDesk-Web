using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using megaDesk_Web.Models;

namespace megaDesk_Web.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public CreateModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeliveryId"] = new SelectList(_context.Set<Delivery>(), "DeliveryId", "DeliveryId");
        ViewData["DeskId"] = new SelectList(_context.Set<Desk>(), "DeskId", "DeskId");
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
