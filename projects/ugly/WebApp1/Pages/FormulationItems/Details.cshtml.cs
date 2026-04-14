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
    public class DetailsModel : PageModel
    {
        private readonly ClassLibrary.Contexts.AppDbContext _context;

        public DetailsModel(ClassLibrary.Contexts.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
