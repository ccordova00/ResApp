using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResApp.Data;
using ResApp.Models;

namespace ResApp.Controllers
{
    public class ResponsibilitiesController : Controller
    {
        private readonly ResAppContext _context;

        public ResponsibilitiesController(ResAppContext context)
        {
            _context = context;
        }

        // GET: Responsibilities
        public async Task<IActionResult> Index()
        {
            var resAppContext = _context.Responsibilities.Include(r => r.Job);
            return View(await resAppContext.ToListAsync());
        }

        // GET: Responsibilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibility = await _context.Responsibilities
                .Include(r => r.Job)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (responsibility == null)
            {
                return NotFound();
            }

            return View(responsibility);
        }

        // GET: Responsibilities/Create
        public IActionResult Create()
        {
            ViewData["JobID"] = new SelectList(_context.Jobs, "ID", "ID");
            return View();
        }

        // POST: Responsibilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,JobID")] Responsibility responsibility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsibility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobID"] = new SelectList(_context.Jobs, "ID", "ID", responsibility.JobID);
            return View(responsibility);
        }

        // GET: Responsibilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibility = await _context.Responsibilities.SingleOrDefaultAsync(m => m.ID == id);
            if (responsibility == null)
            {
                return NotFound();
            }
            ViewData["JobID"] = new SelectList(_context.Jobs, "ID", "ID", responsibility.JobID);
            return View(responsibility);
        }

        // POST: Responsibilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,JobID")] Responsibility responsibility)
        {
            if (id != responsibility.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsibility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsibilityExists(responsibility.ID))
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
            ViewData["JobID"] = new SelectList(_context.Jobs, "ID", "ID", responsibility.JobID);
            return View(responsibility);
        }

        // GET: Responsibilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibility = await _context.Responsibilities
                .Include(r => r.Job)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (responsibility == null)
            {
                return NotFound();
            }

            return View(responsibility);
        }

        // POST: Responsibilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsibility = await _context.Responsibilities.SingleOrDefaultAsync(m => m.ID == id);
            _context.Responsibilities.Remove(responsibility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsibilityExists(int id)
        {
            return _context.Responsibilities.Any(e => e.ID == id);
        }
    }
}
