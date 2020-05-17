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
    public class LocalInventoryController : Controller
    {
        private readonly AIMDbContext _context;

        public LocalInventoryController(AIMDbContext context)
        {
            _context = context;
        }

        // GET: LocalInventory
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocalInventory.ToListAsync());
        }

        // GET: LocalInventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localInventory = await _context.LocalInventory
                .FirstOrDefaultAsync(m => m.AmmoId == id);
            if (localInventory == null)
            {
                return NotFound();
            }

            return View(localInventory);
        }

        // GET: LocalInventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalInventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmmoId,DocNumber,Dodic,Nomenclature,LotNumber,InitialQty,CurrentQty,Location")] LocalInventory localInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localInventory);
        }

        // GET: LocalInventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localInventory = await _context.LocalInventory.FindAsync(id);
            if (localInventory == null)
            {
                return NotFound();
            }
            return View(localInventory);
        }

        // POST: LocalInventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmmoId,DocNumber,Dodic,Nomenclature,LotNumber,InitialQty,CurrentQty,Location")] LocalInventory localInventory)
        {
            if (id != localInventory.AmmoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalInventoryExists(localInventory.AmmoId))
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
            return View(localInventory);
        }

        // GET: LocalInventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localInventory = await _context.LocalInventory
                .FirstOrDefaultAsync(m => m.AmmoId == id);
            if (localInventory == null)
            {
                return NotFound();
            }

            return View(localInventory);
        }

        // POST: LocalInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localInventory = await _context.LocalInventory.FindAsync(id);
            _context.LocalInventory.Remove(localInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalInventoryExists(int id)
        {
            return _context.LocalInventory.Any(e => e.AmmoId == id);
        }
    }
}
