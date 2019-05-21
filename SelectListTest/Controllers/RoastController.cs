using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SelectListTest.Data;
using SelectListTest.Models;

namespace SelectListTest.Controllers
{
    public class RoastController : Controller
    {
        private readonly InventoryDbContext _context;

        public RoastController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: Roast
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roasts.ToListAsync());
        }

        // GET: Roast/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roastModel = await _context.Roasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roastModel == null)
            {
                return NotFound();
            }

            return View(roastModel);
        }

        // GET: Roast/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roast/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RoastModel roastModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roastModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roastModel);
        }

        // GET: Roast/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roastModel = await _context.Roasts.FindAsync(id);
            if (roastModel == null)
            {
                return NotFound();
            }
            return View(roastModel);
        }

        // POST: Roast/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RoastModel roastModel)
        {
            if (id != roastModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roastModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoastModelExists(roastModel.Id))
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
            return View(roastModel);
        }

        // GET: Roast/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roastModel = await _context.Roasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roastModel == null)
            {
                return NotFound();
            }

            return View(roastModel);
        }

        // POST: Roast/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roastModel = await _context.Roasts.FindAsync(id);
            _context.Roasts.Remove(roastModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoastModelExists(int id)
        {
            return _context.Roasts.Any(e => e.Id == id);
        }
    }
}
