using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using F1.Data;
using F1.Models;
using Microsoft.AspNetCore.Authorization;
using F1.ViewModels;

namespace F1.Controllers
{
    public class NationalitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NationalitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nationalities
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nationality.ToListAsync());
        }

        // GET: Nationalities/Details/5
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // GET: Nationalities/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NationName,CapitalCity,PhotoLink")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nationality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nationality);
        }

        // GET: Nationalities/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality.FindAsync(id);
            if (nationality == null)
            {
                return NotFound();
            }
            return View(nationality);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NationName,CapitalCity,PhotoLink")] Nationality nationality)
        {
            if (id != nationality.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nationality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalityExists(nationality.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nationality);
        }

        // GET: Nationalities/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nationality = await _context.Nationality.FindAsync(id);
            _context.Nationality.Remove(nationality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NationalityExists(int id)
        {
            return _context.Nationality.Any(e => e.ID == id);
        }


        public async Task<IActionResult> Drivers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nationality == null)
            {
                return NotFound();
            }
            IEnumerable<RacingDriver> racingDrivers = _context.RacingDriver.Where(s => s.NationalityID == nationality.ID);

            NationalityViewModel nationalityViewModel = new NationalityViewModel()
            {
                Nationality = nationality,
                RacingDrivers = racingDrivers
            };

            return View(nationalityViewModel);
        }


        public async Task<IActionResult> Teams(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nationality == null)
            {
                return NotFound();
            }
            IEnumerable<Team> teams = _context.Team.Where(s => s.NationalityID == nationality.ID);

            NationalityViewModel nationalityViewModel = new NationalityViewModel()
            {
                Nationality = nationality,
                Teams = teams
            };

            return View(nationalityViewModel);
        }
    }
}
