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
    [Route("api/MtnCities")]
    public class MtnCitiesController : Controller
    {
        private readonly lexis_hmsContext _context;

        public MtnCitiesController(lexis_hmsContext context)
        {
            _context = context;
        }

        // GET: api/MtnCities
        [HttpGet]
        public IEnumerable<MtnCity> GetMtnCity()
        {
            return _context.MtnCity;
        }

        // GET: api/MtnCities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtnCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnCity = await _context.MtnCity.SingleOrDefaultAsync(m => m.CityId == id);

            if (mtnCity == null)
            {
                return NotFound();
            }

            return Ok(mtnCity);
        }

        // PUT: api/MtnCities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtnCity([FromRoute] int id, [FromBody] MtnCity mtnCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtnCity.CityId)
            {
                return BadRequest();
            }

            _context.Entry(mtnCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtnCityExists(id))
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

        // POST: api/MtnCities
        [HttpPost]
        public async Task<IActionResult> PostMtnCity([FromBody] MtnCity mtnCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MtnCity.Add(mtnCity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtnCity", new { id = mtnCity.CityId }, mtnCity);
        }

        // DELETE: api/MtnCities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtnCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnCity = await _context.MtnCity.SingleOrDefaultAsync(m => m.CityId == id);
            if (mtnCity == null)
            {
                return NotFound();
            }

            _context.MtnCity.Remove(mtnCity);
            await _context.SaveChangesAsync();

            return Ok(mtnCity);
        }

        private bool MtnCityExists(int id)
        {
            return _context.MtnCity.Any(e => e.CityId == id);
        }
    }
}