using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lexis.hms.data.Models;
using lexis.hms.data.Contracts;
using Newtonsoft.Json;

namespace lexis.hms.services.Controllers
{
    [Produces("application/json")]
    [Route("api/UserProfiles")]
    public class UserProfilesController : Controller
    {
        private readonly lexis_hmsContext _context;
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfilesController(lexis_hmsContext context, IUserProfileRepository userProfileRepository)
        {
            _context = context;
            _userProfileRepository = userProfileRepository;
        }

        // GET: api/UserProfiles
        [HttpGet]
        public IEnumerable<UserProfile> GetUserProfile()
        {
            return _context.UserProfile;
        }

        // GET: api/UserProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userProfile = await _userProfileRepository.GetUserProfile(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return new JsonResult(JsonConvert.SerializeObject(userProfile));
        }

        // PUT: api/UserProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfile([FromRoute] int id, [FromBody] UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfile.UserKey)
            {
                return BadRequest();
            }

            _context.Entry(userProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
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

        // POST: api/UserProfiles
        [HttpPost]
        public async Task<IActionResult> PostUserProfile([FromBody] UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserProfile.Add(userProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserProfile", new { id = userProfile.UserKey }, userProfile);
        }

        // DELETE: api/UserProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userProfile = await _context.UserProfile.SingleOrDefaultAsync(m => m.UserKey == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            _context.UserProfile.Remove(userProfile);
            await _context.SaveChangesAsync();

            return Ok(userProfile);
        }

        private bool UserProfileExists(int id)
        {
            return _context.UserProfile.Any(e => e.UserKey == id);
        }
    }
}