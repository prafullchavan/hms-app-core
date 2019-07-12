using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lexis.hms.data.Models;
using lexis.hms.entity.Models.Master;
using lexis.hms.data.Contracts;

namespace lexis.hms.services.Controllers
{
    [Produces("application/json")]
    [Route("api/MtnCountries")]
    public class MtnCountriesController : Controller
    {
        private readonly lexis_hmsContext _context;
        private readonly ICountryRepository _countyRepository;

        public MtnCountriesController(lexis_hmsContext context, ICountryRepository countyRepository)
        {
            _context = context;
            _countyRepository = countyRepository;
        }

        // GET: api/MtnCountries
        [HttpGet]
        public CountryResponse GetMtnCountry()
        {
           var countries = _countyRepository.GetAllCountries();
            return countries;
        }

        // GET: api/MtnCountries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtnCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnCountry = await _context.MtnCountry.SingleOrDefaultAsync(m => m.CountryId == id);

            if (mtnCountry == null)
            {
                return NotFound();
            }

            return Ok(mtnCountry);
        }

        // PUT: api/MtnCountries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtnCountry([FromRoute] int id, [FromBody] MtnCountry mtnCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtnCountry.CountryId)
            {
                return BadRequest();
            }

            _context.Entry(mtnCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtnCountryExists(id))
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

        // POST: api/MtnCountries
        [HttpPost]
        public async Task<IActionResult> PostMtnCountry([FromBody] Country mtnCountry)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await _countyRepository.CreateCountry(mtnCountry);
                

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                var response = new CountryResponse { status = false, message= "Error occured on page" , countryList = null };
                return new JsonResult(response);
            }
            
        }

        // DELETE: api/MtnCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtnCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtnCountry = await _context.MtnCountry.SingleOrDefaultAsync(m => m.CountryId == id);
            if (mtnCountry == null)
            {
                return NotFound();
            }

            _context.MtnCountry.Remove(mtnCountry);
            await _context.SaveChangesAsync();

            return Ok(mtnCountry);
        }

        private bool MtnCountryExists(int id)
        {
            return _context.MtnCountry.Any(e => e.CountryId == id);
        }
    }
}