using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResApp.Data;
using ResApp.Models;

namespace ResApp.Views
{
    public class EducationController : Controller
    {
        private readonly ResAppContext _context;

        public EducationController(ResAppContext context)
        {
            _context = context;
        }

        // GET: Education
        public async Task<IActionResult> Index()
        {
            var resAppContext = _context.Educations.Include(e => e.Applicant);
            return View(await resAppContext.ToListAsync());
        }

        // GET: Education/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.Applicant)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Education/Create
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName");
            return View();
        }

        // POST: Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Degree,School,GPA,ApplicantID,GradDate")] Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", education.ApplicantID);
            return View(education);
        }

        // GET: Education/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations.SingleOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", education.ApplicantID);
            return View(education);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Degree,School,GPA,ApplicantID,GradDate")] Education education)
        {
            if (id != education.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.ID))
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
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", education.ApplicantID);
            return View(education);
        }

        // GET: Education/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.Applicant)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.SingleOrDefaultAsync(m => m.ID == id);
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.ID == id);
        }
    }
}
