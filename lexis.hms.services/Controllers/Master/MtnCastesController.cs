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
    [Route("api/MtnCastes")]
    public class MtnCastesController : Controller
    {
        private readonly lexis_hmsContext _context;

        public MtnCastesController(lexis_hmsContext context)
        {
            _context = context;
        }

        // GET: api/MtnCastes
        [HttpGet]
        public IEnumerable<MtnCaste> GetMtnCaste()
        {
            return _context.MtnCaste;
        }

        // GET: api/MtnCastes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtnCaste([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnCaste = await _context.MtnCaste.SingleOrDefaultAsync(m => m.ReligionId == id);

            if (mtnCaste == null)
            {
                return NotFound();
            }

            return Ok(mtnCaste);
        }

        // PUT: api/MtnCastes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtnCaste([FromRoute] int id, [FromBody] MtnCaste mtnCaste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtnCaste.ReligionId)
            {
                return BadRequest();
            }

            _context.Entry(mtnCaste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtnCasteExists(id))
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

        // POST: api/MtnCastes
        [HttpPost]
        public async Task<IActionResult> PostMtnCaste([FromBody] MtnCaste mtnCaste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MtnCaste.Add(mtnCaste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtnCaste", new { id = mtnCaste.ReligionId }, mtnCaste);
        }

        // DELETE: api/MtnCastes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtnCaste([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnCaste = await _context.MtnCaste.SingleOrDefaultAsync(m => m.ReligionId == id);
            if (mtnCaste == null)
            {
                return NotFound();
            }

            _context.MtnCaste.Remove(mtnCaste);
            await _context.SaveChangesAsync();

            return Ok(mtnCaste);
        }

        private bool MtnCasteExists(int id)
        {
            return _context.MtnCaste.Any(e => e.ReligionId == id);
        }
    }
}