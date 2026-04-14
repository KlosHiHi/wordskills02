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

namespace WebApp1.Pages.Forms
{
    public class EditModel : PageModel
    {
        private readonly ClassLibrary.Contexts.AppDbContext _context;

        public EditModel(ClassLibrary.Contexts.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Formulation Formulation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulation =  await _context.Formulations.FirstOrDefaultAsync(m => m.Id == id);
            if (formulation == null)
            {
                return NotFound();
            }
            Formulation = formulation;
           ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
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

            _context.Attach(Formulation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormulationExists(Formulation.Id))
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

        private bool FormulationExists(int id)
        {
            return _context.Formulations.Any(e => e.Id == id);
        }
    }
}
