using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibrary.Contexts;
using ClassLibrary.Models;

namespace WebApp1.Pages.Forms
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
        ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Formulation Formulation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Formulations.Add(Formulation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
