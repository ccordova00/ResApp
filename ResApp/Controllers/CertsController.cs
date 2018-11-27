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
    public class CertsController : Controller
    {
        private readonly ResAppContext _context;

        public CertsController(ResAppContext context)
        {
            _context = context;
        }

        // GET: Certs1
        public async Task<IActionResult> Index()
        {
            var resAppContext = _context.Certs.Include(c => c.Applicant);
            return View(await resAppContext.ToListAsync());
        }

        // GET: Certs1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cert = await _context.Certs
                .Include(c => c.Applicant)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cert == null)
            {
                return NotFound();
            }

            return View(cert);
        }

        // GET: Certs1/Create
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName");
            return View();
        }

        // POST: Certs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,DateAcquired,DateExpired,Link,ApplicantID")] Cert cert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "ID", cert.ApplicantID);
            return View(cert);
        }

        // GET: Certs1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cert = await _context.Certs.SingleOrDefaultAsync(m => m.ID == id);
            if (cert == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", cert.ApplicantID);
            return View(cert);
        }

        // POST: Certs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,DateAcquired,DateExpired,Link,ApplicantID")] Cert cert)
        {
            if (id != cert.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertExists(cert.ID))
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
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "ID", cert.ApplicantID);
            return View(cert);
        }

        // GET: Certs1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cert = await _context.Certs
                .Include(c => c.Applicant)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cert == null)
            {
                return NotFound();
            }

            return View(cert);
        }

        // POST: Certs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cert = await _context.Certs.SingleOrDefaultAsync(m => m.ID == id);
            _context.Certs.Remove(cert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertExists(int id)
        {
            return _context.Certs.Any(e => e.ID == id);
        }
    }
}
