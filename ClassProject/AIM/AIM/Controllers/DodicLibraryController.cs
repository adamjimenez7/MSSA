using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AIM.Data;
using AIM.Models;

namespace AIM.Controllers
{
    public class DodicLibraryController : Controller
    {
        private readonly AIMDbContext _context;

        public DodicLibraryController(AIMDbContext context)
        {
            _context = context;
        }

        // GET: DodicLibrary
        public async Task<IActionResult> Index()
        {
            return View(await _context.DodicLibrary.ToListAsync());
        }

        // GET: DodicLibrary/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodicLibrary = await _context.DodicLibrary
                .FirstOrDefaultAsync(m => m.Dodic == id);
            if (dodicLibrary == null)
            {
                return NotFound();
            }

            return View(dodicLibrary);
        }

        // GET: DodicLibrary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DodicLibrary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dodic,Nomenclature")] DodicLibrary dodicLibrary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dodicLibrary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dodicLibrary);
        }

        // GET: DodicLibrary/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodicLibrary = await _context.DodicLibrary.FindAsync(id);
            if (dodicLibrary == null)
            {
                return NotFound();
            }
            return View(dodicLibrary);
        }

        // POST: DodicLibrary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Dodic,Nomenclature")] DodicLibrary dodicLibrary)
        {
            if (id != dodicLibrary.Dodic)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dodicLibrary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DodicLibraryExists(dodicLibrary.Dodic))
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
            return View(dodicLibrary);
        }

        // GET: DodicLibrary/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodicLibrary = await _context.DodicLibrary
                .FirstOrDefaultAsync(m => m.Dodic == id);
            if (dodicLibrary == null)
            {
                return NotFound();
            }

            return View(dodicLibrary);
        }

        // POST: DodicLibrary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dodicLibrary = await _context.DodicLibrary.FindAsync(id);
            _context.DodicLibrary.Remove(dodicLibrary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DodicLibraryExists(string id)
        {
            return _context.DodicLibrary.Any(e => e.Dodic == id);
        }
    }
}
