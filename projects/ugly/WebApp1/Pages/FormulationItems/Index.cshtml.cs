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
    public class IndexModel : PageModel
    {
        private readonly ClassLibrary.Contexts.AppDbContext _context;

        public IndexModel(ClassLibrary.Contexts.AppDbContext context)
        {
            _context = context;
        }

        public IList<FormulationItem> FormulationItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FormulationItem = await _context.FormulationItems
                .Include(f => f.Formulation)
                .Include(f => f.Item).ToListAsync();
        }
    }
}
