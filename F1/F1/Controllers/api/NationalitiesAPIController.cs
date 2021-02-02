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
    [Route("api/Nationalities")]
    [ApiController]
    public class NationalitiesAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NationalitiesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NationalitiesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nationality>>> GetNationality()
        {
            return await _context.Nationality.ToListAsync();
        }

        // GET: api/NationalitiesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nationality>> GetNationality(int id)
        {
            var nationality = await _context.Nationality.FindAsync(id);

            if (nationality == null)
            {
                return NotFound();
            }

            return nationality;
        }

        // PUT: api/NationalitiesAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNationality(int id, Nationality nationality)
        {
            if (id != nationality.ID)
            {
                return BadRequest();
            }

            _context.Entry(nationality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalityExists(id))
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

        // POST: api/NationalitiesAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Nationality>> PostNationality(Nationality nationality)
        {
            _context.Nationality.Add(nationality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNationality", new { id = nationality.ID }, nationality);
        }

        // DELETE: api/NationalitiesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nationality>> DeleteNationality(int id)
        {
            var nationality = await _context.Nationality.FindAsync(id);
            if (nationality == null)
            {
                return NotFound();
            }

            _context.Nationality.Remove(nationality);
            await _context.SaveChangesAsync();

            return nationality;
        }

        private bool NationalityExists(int id)
        {
            return _context.Nationality.Any(e => e.ID == id);
        }
    }
}
