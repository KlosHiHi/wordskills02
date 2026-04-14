using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Contexts;
using ClassLibrary.Models;

namespace WebApp1.Pages.Forms
{
    public class DeleteModel : PageModel
    {
        private readonly ClassLibrary.Contexts.AppDbContext _context;

        public DeleteModel(ClassLibrary.Contexts.AppDbContext context)
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

            var formulation = await _context.Formulations.FirstOrDefaultAsync(m => m.Id == id);

            if (formulation is not null)
            {
                Formulation = formulation;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulation = await _context.Formulations.FindAsync(id);
            if (formulation != null)
            {
                Formulation = formulation;
                _context.Formulations.Remove(Formulation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
