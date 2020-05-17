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
    public class SingleInventoryController : Controller
    {
        private readonly AIMDbContext _context;

        public SingleInventoryController(AIMDbContext context)
        {
            _context = context;
        }

        // GET: SingleInventory
        public async Task<IActionResult> Index()
        {
            return View(await _context.SingleInventory.ToListAsync());
        }

        // GET: SingleInventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleInventory = await _context.SingleInventory
                .FirstOrDefaultAsync(m => m.Da3020Id == id);
            if (singleInventory == null)
            {
                return NotFound();
            }

            return View(singleInventory);
        }

        // GET: SingleInventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SingleInventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Da3020Id,UserId,Da5515id,DocNumber,Dodic,Nomenclature,LotNumber,Location,Date,ActionTaken,Qtylost,Qtygained,Balance")] SingleInventory singleInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singleInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(singleInventory);
        }

        // GET: SingleInventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleInventory = await _context.SingleInventory.FindAsync(id);
            if (singleInventory == null)
            {
                return NotFound();
            }
            return View(singleInventory);
        }

        // POST: SingleInventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Da3020Id,UserId,Da5515id,DocNumber,Dodic,Nomenclature,LotNumber,Location,Date,ActionTaken,Qtylost,Qtygained,Balance")] SingleInventory singleInventory)
        {
            if (id != singleInventory.Da3020Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singleInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingleInventoryExists(singleInventory.Da3020Id))
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
            return View(singleInventory);
        }

        // GET: SingleInventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleInventory = await _context.SingleInventory
                .FirstOrDefaultAsync(m => m.Da3020Id == id);
            if (singleInventory == null)
            {
                return NotFound();
            }

            return View(singleInventory);
        }

        // POST: SingleInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singleInventory = await _context.SingleInventory.FindAsync(id);
            _context.SingleInventory.Remove(singleInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SingleInventoryExists(int id)
        {
            return _context.SingleInventory.Any(e => e.Da3020Id == id);
        }
    }
}
