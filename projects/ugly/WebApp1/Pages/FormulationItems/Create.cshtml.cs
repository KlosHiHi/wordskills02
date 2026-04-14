using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibrary.Contexts;
using ClassLibrary.Models;

namespace WebApp1.Pages.FormulationItems
{
    public class CreateModel : PageModel
    {
        private readonly ClassLibrary.Contexts.AppDbContext _context;

        public CreateModel(ClassLibrary.Contexts.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FormulationId"] = new SelectList(_context.Formulations, "Id", "Id");
        ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public FormulationItem FormulationItem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FormulationItems.Add(FormulationItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
