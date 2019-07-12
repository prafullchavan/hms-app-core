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
    [Route("api/MtnStates")]
    public class MtnStatesController : Controller
    {
        private readonly lexis_hmsContext _context;

        public MtnStatesController(lexis_hmsContext context)
        {
            _context = context;
        }

        // GET: api/MtnStates
        [HttpGet]
        public IEnumerable<MtnState> GetMtnState()
        {
            return _context.MtnState;
        }

        // GET: api/MtnStates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtnState([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnState = await _context.MtnState.SingleOrDefaultAsync(m => m.StateId == id);

            if (mtnState == null)
            {
                return NotFound();
            }

            return Ok(mtnState);
        }

        // PUT: api/MtnStates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtnState([FromRoute] int id, [FromBody] MtnState mtnState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtnState.StateId)
            {
                return BadRequest();
            }

            _context.Entry(mtnState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtnStateExists(id))
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

        // POST: api/MtnStates
        [HttpPost]
        public async Task<IActionResult> PostMtnState([FromBody] MtnState mtnState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MtnState.Add(mtnState);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtnState", new { id = mtnState.StateId }, mtnState);
        }

        // DELETE: api/MtnStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtnState([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnState = await _context.MtnState.SingleOrDefaultAsync(m => m.StateId == id);
            if (mtnState == null)
            {
                return NotFound();
            }

            _context.MtnState.Remove(mtnState);
            await _context.SaveChangesAsync();

            return Ok(mtnState);
        }

        private bool MtnStateExists(int id)
        {
            return _context.MtnState.Any(e => e.StateId == id);
        }
    }
}