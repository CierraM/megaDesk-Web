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
            //for populating selects
            ViewData["DeliveryId"] = new SelectList(_context.Set<Delivery>(), "DeliveryId", "deliverySpeed");

            ViewData["DesktopMaterialId"] = new SelectList(_context.Set<DesktopMaterial>(), "DesktopMaterialId", "MaterialName");
            return Page();
        }
        //binding: makes it so the stuff from the form automatically goes where we can access it
        [BindProperty]
        public Desk Desk { get; set; }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Desk stuff
            //save desk before adding it to the desk quote
            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();
            //DeskQuote stuff
            DeskQuote.QuoteDate = DateTime.Now;

            DeskQuote.DeskId = Desk.DeskId;
            DeskQuote.Desk = Desk;

            //Add desk to desk quote
            DeskQuote.Price = DeskQuote.calcPrice(_context);
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
