using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models;

namespace Citrix.Controllers
{
    [Route("api/Dagdeel")]
    [ApiController]
    public class DagdeelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DagdeelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dagdeels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dagdeel>>> GetDagdeel()
        {
            return await _context.Dagdeel.ToListAsync();
        }

        // GET: api/Dagdeels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dagdeel>> GetDagdeel(int id)
        {
            var dagdeel = await _context.Dagdeel.FindAsync(id);

            if (dagdeel == null)
            {
                return NotFound();
            }

            return dagdeel;
        }

        // PUT: api/Dagdeels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDagdeel(int id, Dagdeel dagdeel)
        {
            if (id != dagdeel.ID)
            {
                return BadRequest();
            }

            _context.Entry(dagdeel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DagdeelExists(id))
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

        // POST: api/Dagdeels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dagdeel>> PostDagdeel(Dagdeel dagdeel)
        {
            _context.Dagdeel.Add(dagdeel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDagdeel", new { id = dagdeel.ID }, dagdeel);
        }

        // DELETE: api/Dagdeels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dagdeel>> DeleteDagdeel(int id)
        {
            var dagdeel = await _context.Dagdeel.FindAsync(id);
            if (dagdeel == null)
            {
                return NotFound();
            }

            _context.Dagdeel.Remove(dagdeel);
            await _context.SaveChangesAsync();

            return dagdeel;
        }

        private bool DagdeelExists(int id)
        {
            return _context.Dagdeel.Any(e => e.ID == id);
        }
    }
}
