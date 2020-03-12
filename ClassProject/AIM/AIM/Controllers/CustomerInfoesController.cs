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
    public class CustomerInfoesController : Controller
    {
        private readonly ProjectDatabaseDbContext _context;

        public CustomerInfoesController(ProjectDatabaseDbContext context)
        {
            _context = context;
        }

        // GET: CustomerInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerInfo.ToListAsync());
        }

        // GET: CustomerInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInfo = await _context.CustomerInfo
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            return View(customerInfo);
        }

        // GET: CustomerInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Rank,Unit")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerInfo);
        }

        // GET: CustomerInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInfo = await _context.CustomerInfo.FindAsync(id);
            if (customerInfo == null)
            {
                return NotFound();
            }
            return View(customerInfo);
        }

        // POST: CustomerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,Rank,Unit")] CustomerInfo customerInfo)
        {
            if (id != customerInfo.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerInfoExists(customerInfo.CustomerId))
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
            return View(customerInfo);
        }

        // GET: CustomerInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInfo = await _context.CustomerInfo
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            return View(customerInfo);
        }

        // POST: CustomerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerInfo = await _context.CustomerInfo.FindAsync(id);
            _context.CustomerInfo.Remove(customerInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerInfoExists(int id)
        {
            return _context.CustomerInfo.Any(e => e.CustomerId == id);
        }
    }
}
