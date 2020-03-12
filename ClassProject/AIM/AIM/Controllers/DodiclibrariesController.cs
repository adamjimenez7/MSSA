using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAMMIT.Data;
using DAMMIT.Models;

namespace DAMMIT.Controllers
{
    public class DodiclibrariesController : Controller
    {
        private readonly ProjectDatabaseDbContext _context;

        public DodiclibrariesController(ProjectDatabaseDbContext context)
        {
            _context = context;
        }

        // GET: Dodiclibraries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dodiclibrary.ToListAsync());
        }

        // GET: Dodiclibraries/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodiclibrary = await _context.Dodiclibrary
                .FirstOrDefaultAsync(m => m.Dodic == id);
            if (dodiclibrary == null)
            {
                return NotFound();
            }

            return View(dodiclibrary);
        }

        // GET: Dodiclibraries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dodiclibraries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dodic,Nomenclature")] Dodiclibrary dodiclibrary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dodiclibrary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dodiclibrary);
        }

        // GET: Dodiclibraries/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodiclibrary = await _context.Dodiclibrary.FindAsync(id);
            if (dodiclibrary == null)
            {
                return NotFound();
            }
            return View(dodiclibrary);
        }

        // POST: Dodiclibraries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Dodic,Nomenclature")] Dodiclibrary dodiclibrary)
        {
            if (id != dodiclibrary.Dodic)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dodiclibrary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DodiclibraryExists(dodiclibrary.Dodic))
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
            return View(dodiclibrary);
        }

        // GET: Dodiclibraries/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodiclibrary = await _context.Dodiclibrary
                .FirstOrDefaultAsync(m => m.Dodic == id);
            if (dodiclibrary == null)
            {
                return NotFound();
            }

            return View(dodiclibrary);
        }

        // POST: Dodiclibraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dodiclibrary = await _context.Dodiclibrary.FindAsync(id);
            _context.Dodiclibrary.Remove(dodiclibrary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DodiclibraryExists(string id)
        {
            return _context.Dodiclibrary.Any(e => e.Dodic == id);
        }
    }
}
