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
    public class LocalTransactionsController : Controller
    {
        private readonly ProjectDatabaseDbContext _context;

        public LocalTransactionsController(ProjectDatabaseDbContext context)
        {
            _context = context;
        }

        // GET: LocalTransactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocalTransaction.ToListAsync());
        }

        // GET: LocalTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localTransaction = await _context.LocalTransaction
                .FirstOrDefaultAsync(m => m.Da5515id == id);
            if (localTransaction == null)
            {
                return NotFound();
            }

            return View(localTransaction);
        }

        // GET: LocalTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Da5515id,UserId,CustomerId,DocNumber,RecUnit,RecDate,Tidate,Notes,Da5515copy")] LocalTransaction localTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localTransaction);
        }

        // GET: LocalTransactions/Edit/5
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

        // POST: LocalTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Da5515id,UserId,CustomerId,DocNumber,RecUnit,RecDate,Tidate,Notes,Da5515copy")] LocalTransaction localTransaction)
        {
            if (id != localTransaction.Da5515id)
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
                    if (!LocalTransactionExists(localTransaction.Da5515id))
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

        // GET: LocalTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localTransaction = await _context.LocalTransaction
                .FirstOrDefaultAsync(m => m.Da5515id == id);
            if (localTransaction == null)
            {
                return NotFound();
            }

            return View(localTransaction);
        }

        // POST: LocalTransactions/Delete/5
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
            return _context.LocalTransaction.Any(e => e.Da5515id == id);
        }
    }
}
