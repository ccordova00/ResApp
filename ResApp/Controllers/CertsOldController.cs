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
    public class CertsOldController : Controller
    {
        private readonly ResAppContext _context;

        public CertsOldController(ResAppContext context)
        {
            _context = context;
        }

        // GET: Certs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Certs.ToListAsync());
        }

        // GET: Certs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cert = await _context.Certs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cert == null)
            {
                return NotFound();
            }

            return View(cert);
        }

        // GET: Certs/Create
        public IActionResult Create()
        {
            var applicants = from a in _context.Applicants
                             .OrderBy(a => a.LastName)
                             .ToList()
                             select a;

            ViewBag.Applicants = applicants;

            return View();
        }

        // POST: Certs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantID,Description,DateAcquired,DateExpired,Link")] Cert cert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cert);
        }

        // GET: Certs/Edit/5
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

            return View(cert);
        }

        // POST: Certs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,DateAcquired,DateExpired,Link")] Cert cert)
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
            return View(cert);
        }

        // GET: Certs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cert = await _context.Certs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cert == null)
            {
                return NotFound();
            }

            return View(cert);
        }

        // POST: Certs/Delete/5
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
