using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lexis.hms.data.Models;
using Newtonsoft.Json;
using lexis.hms.services.Contracts;
using lexis.hms.entity.Models.Login;

namespace lexis.hms.services.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly ILoginManager _loginManager;
        public LoginController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = _loginManager.Authenticate(authenticationRequest);

                return new JsonResult(response);
            }
            catch (Exception)
            {
                var response = new AuthenticationResponse { status = false, authToken = ""};
                return new JsonResult(response);
            }
        }

        private AuthenticationResponse GetAuthenticationResponse()
        {
            var response = new AuthenticationResponse { status = true, authToken = "sadasfhasfgashasnq3874yfbshf" };
            return response;
        }
        

        //private readonly lexis_hmsContext _context;

        //public LoginController(lexis_hmsContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Login
        //[HttpGet]
        //public IEnumerable<LoginSession> GetLoginSession()
        //{
        //    return _context.LoginSession;
        //}

        //// GET: api/Login/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetLoginSession([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var loginSession = await _context.LoginSession.SingleOrDefaultAsync(m => m.LoginSessionId == id);

        //    if (loginSession == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(loginSession);
        //}

        //// PUT: api/Login/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLoginSession([FromRoute] int id, [FromBody] LoginSession loginSession)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != loginSession.LoginSessionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(loginSession).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LoginSessionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Login
        //[HttpPost]
        //public async Task<IActionResult> PostLoginSession([FromBody] LoginSession loginSession)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.LoginSession.Add(loginSession);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetLoginSession", new { id = loginSession.LoginSessionId }, loginSession);
        //}

        //// DELETE: api/Login/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLoginSession([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var loginSession = await _context.LoginSession.SingleOrDefaultAsync(m => m.LoginSessionId == id);
        //    if (loginSession == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.LoginSession.Remove(loginSession);
        //    await _context.SaveChangesAsync();

        //    return Ok(loginSession);
        //}

        //private bool LoginSessionExists(int id)
        //{
        //    return _context.LoginSession.Any(e => e.LoginSessionId == id);
        //}
    }
}