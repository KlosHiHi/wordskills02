using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Contexts;
using ClassLibrary.Models;

namespace WebApp1.Pages.FormulationItems
{
    public class EditModel : PageModel
    {
        private readonly ClassLibrary.Contexts.AppDbContext _context;

        public EditModel(ClassLibrary.Contexts.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FormulationItem FormulationItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulationitem =  await _context.FormulationItems.FirstOrDefaultAsync(m => m.FormulationId == id);
            if (formulationitem == null)
            {
                return NotFound();
            }
            FormulationItem = formulationitem;
           ViewData["FormulationId"] = new SelectList(_context.Formulations, "Id", "Id");
           ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FormulationItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormulationItemExists(FormulationItem.FormulationId))
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

        private bool FormulationItemExists(int id)
        {
            return _context.FormulationItems.Any(e => e.FormulationId == id);
        }
    }
}
