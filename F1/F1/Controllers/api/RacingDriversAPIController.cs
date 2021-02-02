using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1.Data;
using F1.Models;

namespace F1.Controllers
{
    [Route("api/RacingDrivers")]
    [ApiController]
    public class RacingDriversAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RacingDriversAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RacingDriversAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RacingDriver>>> GetRacingDriver()
        {
            return await _context.RacingDriver.ToListAsync();
        }

        // GET: api/RacingDriversAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RacingDriver>> GetRacingDriver(int id)
        {
            var racingDriver = await _context.RacingDriver.FindAsync(id);

            if (racingDriver == null)
            {
                return NotFound();
            }

            return racingDriver;
        }

        // PUT: api/RacingDriversAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRacingDriver(int id, RacingDriver racingDriver)
        {
            if (id != racingDriver.ID)
            {
                return BadRequest();
            }

            _context.Entry(racingDriver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacingDriverExists(id))
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

        // POST: api/RacingDriversAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RacingDriver>> PostRacingDriver(RacingDriver racingDriver)
        {
            _context.RacingDriver.Add(racingDriver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRacingDriver", new { id = racingDriver.ID }, racingDriver);
        }

        // DELETE: api/RacingDriversAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RacingDriver>> DeleteRacingDriver(int id)
        {
            var racingDriver = await _context.RacingDriver.FindAsync(id);
            if (racingDriver == null)
            {
                return NotFound();
            }

            _context.RacingDriver.Remove(racingDriver);
            await _context.SaveChangesAsync();

            return racingDriver;
        }

        private bool RacingDriverExists(int id)
        {
            return _context.RacingDriver.Any(e => e.ID == id);
        }
    }
}
