using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models.Models.Klachten;

namespace Citrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlachtModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KlachtModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KlachtModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KlachtModel>>> GetKlacht()
        {
            return await _context.Klacht.ToListAsync();
        }

        // GET: api/KlachtModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KlachtModel>> GetKlachtModel(int id)
        {
            var klachtModel = await _context.Klacht.FindAsync(id);

            if (klachtModel == null)
            {
                return NotFound();
            }

            return klachtModel;
        }

        // PUT: api/KlachtModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlachtModel(int id, KlachtModel klachtModel)
        {
            if (id != klachtModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(klachtModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlachtModelExists(id))
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

        // POST: api/KlachtModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<KlachtModel>> PostKlachtModel(KlachtModel klachtModel)
        {
            _context.Klacht.Add(klachtModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKlachtModel", new { id = klachtModel.Id }, klachtModel);
        }

        // DELETE: api/KlachtModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KlachtModel>> DeleteKlachtModel(int id)
        {
            var klachtModel = await _context.Klacht.FindAsync(id);
            if (klachtModel == null)
            {
                return NotFound();
            }

            _context.Klacht.Remove(klachtModel);
            await _context.SaveChangesAsync();

            return klachtModel;
        }

        private bool KlachtModelExists(int id)
        {
            return _context.Klacht.Any(e => e.Id == id);
        }
    }
}
