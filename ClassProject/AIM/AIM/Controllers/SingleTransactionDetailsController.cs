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
    public class SingleTransactionDetailsController : Controller
    {
        private readonly AIMDbContext _context;

        public SingleTransactionDetailsController(AIMDbContext context)
        {
            _context = context;
        }

        // GET: SingleTransactionDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.SingleTransactionDetails.ToListAsync());
        }

        // GET: SingleTransactionDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleTransactionDetails = await _context.SingleTransactionDetails
                .FirstOrDefaultAsync(m => m.LineId == id);
            if (singleTransactionDetails == null)
            {
                return NotFound();
            }

            return View(singleTransactionDetails);
        }

        // GET: SingleTransactionDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SingleTransactionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineId,Da5515Id,Dodic,Nomenclature,LotNumber,Qtyissued,ResIssued,Qtyreturned,ResReturned,Notes")] SingleTransactionDetails singleTransactionDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singleTransactionDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(singleTransactionDetails);
        }

        // GET: SingleTransactionDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleTransactionDetails = await _context.SingleTransactionDetails.FindAsync(id);
            if (singleTransactionDetails == null)
            {
                return NotFound();
            }
            return View(singleTransactionDetails);
        }

        // POST: SingleTransactionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LineId,Da5515Id,Dodic,Nomenclature,LotNumber,Qtyissued,ResIssued,Qtyreturned,ResReturned,Notes")] SingleTransactionDetails singleTransactionDetails)
        {
            if (id != singleTransactionDetails.LineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singleTransactionDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingleTransactionDetailsExists(singleTransactionDetails.LineId))
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
            return View(singleTransactionDetails);
        }

        // GET: SingleTransactionDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleTransactionDetails = await _context.SingleTransactionDetails
                .FirstOrDefaultAsync(m => m.LineId == id);
            if (singleTransactionDetails == null)
            {
                return NotFound();
            }

            return View(singleTransactionDetails);
        }

        // POST: SingleTransactionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singleTransactionDetails = await _context.SingleTransactionDetails.FindAsync(id);
            _context.SingleTransactionDetails.Remove(singleTransactionDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SingleTransactionDetailsExists(int id)
        {
            return _context.SingleTransactionDetails.Any(e => e.LineId == id);
        }
    }
}
