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
    public class OnlineResourcesController : Controller
    {
        private readonly ResAppContext _context;

        public OnlineResourcesController(ResAppContext context)
        {
            _context = context;
        }

        // GET: OnlineResources
        public async Task<IActionResult> Index()
        {
            var resAppContext = _context.Links.Include(l => l.Applicant);
            return View(await resAppContext.ToListAsync());
        }

        // GET: OnlineResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links
                .Include(l => l.Applicant)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // GET: OnlineResources/Create
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName");
            return View();
        }

        // POST: OnlineResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LinkUrl,Description,ApplicantID")] Link link)
        {
            if (ModelState.IsValid)
            {
                _context.Add(link);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", link.ApplicantID);
            return View(link);
        }

        // GET: OnlineResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links.SingleOrDefaultAsync(m => m.ID == id);
            if (link == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", link.ApplicantID);
            return View(link);
        }

        // POST: OnlineResources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LinkUrl,Description,ApplicantID")] Link link)
        {
            if (id != link.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(link);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinkExists(link.ID))
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
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ID", "FullName", link.ApplicantID);
            return View(link);
        }

        // GET: OnlineResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links
                .Include(l => l.Applicant)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // POST: OnlineResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var link = await _context.Links.SingleOrDefaultAsync(m => m.ID == id);
            _context.Links.Remove(link);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinkExists(int id)
        {
            return _context.Links.Any(e => e.ID == id);
        }
    }
}
