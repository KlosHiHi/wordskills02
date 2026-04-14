using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Contexts;
using ClassLibrary.Models;

namespace WebApp1.Pages.FormulationItems
{
    public class DeleteModel : PageModel
    {
        private readonly ClassLibrary.Contexts.AppDbContext _context;

        public DeleteModel(ClassLibrary.Contexts.AppDbContext context)
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

            var formulationitem = await _context.FormulationItems.FirstOrDefaultAsync(m => m.FormulationId == id);

            if (formulationitem is not null)
            {
                FormulationItem = formulationitem;

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

            var formulationitem = await _context.FormulationItems.FindAsync(id);
            if (formulationitem != null)
            {
                FormulationItem = formulationitem;
                _context.FormulationItems.Remove(FormulationItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
