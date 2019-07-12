using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lexis.hms.data.Models;

namespace lexis.hms.services.Controllers.Master
{
    [Produces("application/json")]
    [Route("api/MtnReligions")]
    public class MtnReligionsController : Controller
    {
        private readonly lexis_hmsContext _context;

        public MtnReligionsController(lexis_hmsContext context)
        {
            _context = context;
        }

        // GET: api/MtnReligions
        [HttpGet]
        public IEnumerable<MtnReligion> GetMtnReligion()
        {
            return _context.MtnReligion;
        }

        // GET: api/MtnReligions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtnReligion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnReligion = await _context.MtnReligion.SingleOrDefaultAsync(m => m.ReligionId == id);

            if (mtnReligion == null)
            {
                return NotFound();
            }

            return Ok(mtnReligion);
        }

        // PUT: api/MtnReligions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtnReligion([FromRoute] int id, [FromBody] MtnReligion mtnReligion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtnReligion.ReligionId)
            {
                return BadRequest();
            }

            _context.Entry(mtnReligion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtnReligionExists(id))
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

        // POST: api/MtnReligions
        [HttpPost]
        public async Task<IActionResult> PostMtnReligion([FromBody] MtnReligion mtnReligion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MtnReligion.Add(mtnReligion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtnReligion", new { id = mtnReligion.ReligionId }, mtnReligion);
        }

        // DELETE: api/MtnReligions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtnReligion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnReligion = await _context.MtnReligion.SingleOrDefaultAsync(m => m.ReligionId == id);
            if (mtnReligion == null)
            {
                return NotFound();
            }

            _context.MtnReligion.Remove(mtnReligion);
            await _context.SaveChangesAsync();

            return Ok(mtnReligion);
        }

        private bool MtnReligionExists(int id)
        {
            return _context.MtnReligion.Any(e => e.ReligionId == id);
        }
    }
}