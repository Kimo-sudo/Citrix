using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Citrix.Data;
using Citrix.Models.Models.Klachten;
using Citrix.Data.Services;

namespace Citrix.Controllers
{
    [Route("api/klachtmodel")]
    [ApiController]
    public class KlachtModelsController : ControllerBase
    {
        private readonly IDataService<KlachtModel> _db;


        public KlachtModelsController(IDataService<KlachtModel> db)
        {
            _db = db;
        }
        // GET: api/KlachtModels
        [HttpGet]
        public async Task<IEnumerable<KlachtModel>> GetKlacht()
        {
            return await _db.GetAll();
        }

        // GET: api/KlachtModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KlachtModel>> GetKlachtModel(int id)
        {
            var klachtModel = await _db.Get(id);

            if (klachtModel == null)
            {
                return NotFound();
            }

            return klachtModel;
        }

        // PUT: api/KlachtModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlachtModel(int id, KlachtModel klachtModel)
        {
            if (id != klachtModel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _db.Create(klachtModel);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
                
            }
            return NoContent();
        }

        // POST: api/KlachtModels
        [HttpPost]
        public async Task<ActionResult<KlachtModel>> PostKlachtModel(KlachtModel klachtModel)
        {
            await _db.Create(klachtModel);
            return CreatedAtAction("GetKlachtModel", new { id = klachtModel.Id }, klachtModel);
        }

        // DELETE: api/KlachtModels/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteKlachtModel(int id)
        {
            return await _db.Delete(id);

        }
    }
}
