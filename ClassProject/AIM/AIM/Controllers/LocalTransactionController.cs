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
    public class LocalTransactionController : Controller
    {
        private readonly AIMDbContext _context;

        public LocalTransactionController(AIMDbContext context)
        {
            _context = context;
        }

        // GET: LocalTransaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocalTransaction.ToListAsync());
        }

        // GET: LocalTransaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localTransaction = await _context.LocalTransaction
                .FirstOrDefaultAsync(m => m.Da5515Id == id);
            if (localTransaction == null)
            {
                return NotFound();
            }

            return View(localTransaction);
        }

        // GET: LocalTransaction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalTransaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Da5515Id,UserId,CustomerId,DocNumber,RecUnit,RecDate,Tidate,Notes,Da5515copy")] LocalTransaction localTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localTransaction);
        }

        // GET: LocalTransaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localTransaction = await _context.LocalTransaction.FindAsync(id);
            if (localTransaction == null)
            {
                return NotFound();
            }
            return View(localTransaction);
        }

        // POST: LocalTransaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Da5515Id,UserId,CustomerId,DocNumber,RecUnit,RecDate,Tidate,Notes,Da5515copy")] LocalTransaction localTransaction)
        {
            if (id != localTransaction.Da5515Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalTransactionExists(localTransaction.Da5515Id))
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
            return View(localTransaction);
        }

        // GET: LocalTransaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localTransaction = await _context.LocalTransaction
                .FirstOrDefaultAsync(m => m.Da5515Id == id);
            if (localTransaction == null)
            {
                return NotFound();
            }

            return View(localTransaction);
        }

        // POST: LocalTransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localTransaction = await _context.LocalTransaction.FindAsync(id);
            _context.LocalTransaction.Remove(localTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalTransactionExists(int id)
        {
            return _context.LocalTransaction.Any(e => e.Da5515Id == id);
        }
    }
}
