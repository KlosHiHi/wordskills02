using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Contexts;
using ClassLibrary.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FormulationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Formulation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formulation>>> GetFormulations()
        {
            var list = await _context.Formulations.Include(f=>f.Product).Include(f=>f.FormulationItems).ToListAsync();
            List<Formulation> newList = new();
            foreach(var item in list)
            {
                item.Product.Formulations = null!;
                newList.Add(item);
            }

            return newList;
        }

        // GET: api/Formulation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Formulation>> GetFormulation(int id)
        {
            var formulation = await _context.Formulations.FindAsync(id);

            if (formulation == null)
            {
                return NotFound();
            }

            return formulation;
        }

        // PUT: api/Formulation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormulation(int id, Formulation formulation)
        {
            if (id != formulation.Id)
            {
                return BadRequest();
            }

            _context.Entry(formulation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormulationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Formulation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Formulation>> PostFormulation(Formulation formulation)
        {
            _context.Formulations.Add(formulation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormulation", new { id = formulation.Id }, formulation);
        }

        // DELETE: api/Formulation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormulation(int id)
        {
            var formulation = await _context.Formulations.FindAsync(id);
            if (formulation == null)
            {
                return NotFound();
            }

            _context.Formulations.Remove(formulation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormulationExists(int id)
        {
            return _context.Formulations.Any(e => e.Id == id);
        }
    }
}
