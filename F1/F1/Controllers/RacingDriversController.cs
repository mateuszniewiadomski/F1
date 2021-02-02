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

namespace F1.Controllers
{
    public class RacingDriversController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RacingDriversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RacingDrivers
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RacingDriver.Include(r => r.Nationality).Include(r => r.Team);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RacingDrivers/Details/5
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racingDriver = await _context.RacingDriver
                .Include(r => r.Nationality)
                .Include(r => r.Team)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (racingDriver == null)
            {
                return NotFound();
            }

            return View(racingDriver);
        }

        // GET: RacingDrivers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["NationalityID"] = new SelectList(_context.Nationality, "ID", "NationName");
            ViewData["TeamID"] = new SelectList(_context.Team, "ID", "ConstructorName");
            return View();
        }

        // POST: RacingDrivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Firstname,Lastname,StartNumber,CareerWins,DateOfBirth,PhotoLink,NationalityID,TeamID")] RacingDriver racingDriver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(racingDriver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NationalityID"] = new SelectList(_context.Nationality, "ID", "NationName", racingDriver.NationalityID);
            ViewData["TeamID"] = new SelectList(_context.Team, "ID", "ConstructorName", racingDriver.TeamID);
            return View(racingDriver);
        }

        // GET: RacingDrivers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racingDriver = await _context.RacingDriver.FindAsync(id);
            if (racingDriver == null)
            {
                return NotFound();
            }
            ViewData["NationalityID"] = new SelectList(_context.Nationality, "ID", "NationName", racingDriver.NationalityID);
            ViewData["TeamID"] = new SelectList(_context.Team, "ID", "ConstructorName", racingDriver.TeamID);
            return View(racingDriver);
        }

        // POST: RacingDrivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Firstname,Lastname,StartNumber,CareerWins,DateOfBirth,PhotoLink,NationalityID,TeamID")] RacingDriver racingDriver)
        {
            if (id != racingDriver.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(racingDriver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RacingDriverExists(racingDriver.ID))
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
            ViewData["NationalityID"] = new SelectList(_context.Nationality, "ID", "NationName", racingDriver.NationalityID);
            ViewData["TeamID"] = new SelectList(_context.Team, "ID", "ConstructorName", racingDriver.TeamID);
            return View(racingDriver);
        }

        // GET: RacingDrivers/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racingDriver = await _context.RacingDriver
                .Include(r => r.Nationality)
                .Include(r => r.Team)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (racingDriver == null)
            {
                return NotFound();
            }

            return View(racingDriver);
        }

        // POST: RacingDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var racingDriver = await _context.RacingDriver.FindAsync(id);
            _context.RacingDriver.Remove(racingDriver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RacingDriverExists(int id)
        {
            return _context.RacingDriver.Any(e => e.ID == id);
        }
    }
}
