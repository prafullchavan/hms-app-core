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
    [Route("api/MtnAddressTypes")]
    public class MtnAddressTypesController : Controller
    {
        private readonly lexis_hmsContext _context;

        public MtnAddressTypesController(lexis_hmsContext context)
        {
            _context = context;
        }

        // GET: api/MtnAddressTypes
        [HttpGet]
        public IEnumerable<MtnAddressType> GetMtnAddressType()
        {
            return _context.MtnAddressType;
        }

        // GET: api/MtnAddressTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtnAddressType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnAddressType = await _context.MtnAddressType.SingleOrDefaultAsync(m => m.AddressTypeId == id);

            if (mtnAddressType == null)
            {
                return NotFound();
            }

            return Ok(mtnAddressType);
        }

        // PUT: api/MtnAddressTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtnAddressType([FromRoute] int id, [FromBody] MtnAddressType mtnAddressType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtnAddressType.AddressTypeId)
            {
                return BadRequest();
            }

            _context.Entry(mtnAddressType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtnAddressTypeExists(id))
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

        // POST: api/MtnAddressTypes
        [HttpPost]
        public async Task<IActionResult> PostMtnAddressType([FromBody] MtnAddressType mtnAddressType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MtnAddressType.Add(mtnAddressType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtnAddressType", new { id = mtnAddressType.AddressTypeId }, mtnAddressType);
        }

        // DELETE: api/MtnAddressTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtnAddressType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnAddressType = await _context.MtnAddressType.SingleOrDefaultAsync(m => m.AddressTypeId == id);
            if (mtnAddressType == null)
            {
                return NotFound();
            }

            _context.MtnAddressType.Remove(mtnAddressType);
            await _context.SaveChangesAsync();

            return Ok(mtnAddressType);
        }

        private bool MtnAddressTypeExists(int id)
        {
            return _context.MtnAddressType.Any(e => e.AddressTypeId == id);
        }
    }
}