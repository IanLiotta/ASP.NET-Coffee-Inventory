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
    public class InventoryController : Controller
    {
        private readonly InventoryDbContext _context;

        public InventoryController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: Inventory
        public async Task<IActionResult> Index()
        {
            var fullInventory = await _context.Inventory.Select(s => new InventoryViewModel
            {
                ItemId = s.Id,
                CoffeeFullName = $"{s.Coffee.Country.Name} {s.Coffee.Variety.Name}",
                VendorName = s.Vendor.Name,
                RoastName = s.Roast.Name,
                PricePerLbs = s.PricePerLbs,
                LbsOnHand = s.LbsOnHand
            })
                .ToListAsync();
            return View(fullInventory);
        }

        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryModel = await _context.Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryModel == null)
            {
                return NotFound();
            }

            return View(inventoryModel);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            var coffees = _context.Coffees
                .Select(s => new
                {
                    Id = s.Id,
                    coffeeName = $"{s.Country.Name} {s.Variety.Name}",
                })
                .ToList();
            InventoryViewModel ivm = new InventoryViewModel
            {
                Coffees = new SelectList(coffees, "Id", "coffeeName"),
                Vendors = new SelectList(_context.Vendors.ToList(), "Id", "Name"),
                Roasts = new SelectList(_context.Roasts.ToList(), "Id", "Name")
            };
            return View(ivm);
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryViewModel ivm)
        {
            if (ModelState.IsValid)
            {
                InventoryModel newItem = new InventoryModel
                {
                    Coffee = _context.Coffees.Find(ivm.CoffeeId),
                    Vendor = _context.Vendors.Find(ivm.VendorId),
                    Roast = _context.Roasts.Find(ivm.RoastId),
                    PricePerLbs = ivm.PricePerLbs,
                    LbsOnHand = ivm.LbsOnHand
                };
            
                _context.Add(newItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ivm);
        }

        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryModel = await _context.Inventory.FindAsync(id);
            if (inventoryModel == null)
            {
                return NotFound();
            }
            return View(inventoryModel);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PricePerLbs,LbsOnHand")] InventoryModel inventoryModel)
        {
            if (id != inventoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryModelExists(inventoryModel.Id))
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
            return View(inventoryModel);
        }

        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryModel = await _context.Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryModel == null)
            {
                return NotFound();
            }

            return View(inventoryModel);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryModel = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventoryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryModelExists(int id)
        {
            return _context.Inventory.Any(e => e.Id == id);
        }
    }
}
