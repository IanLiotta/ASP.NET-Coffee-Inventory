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
    public class CoffeeController : Controller
    {
        private readonly InventoryDbContext _context;

        public CoffeeController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: Coffee
        public async Task<IActionResult> Index()
        {
            List<CoffeeViewModel> lcvm = new List<CoffeeViewModel>();
            List<CoffeeModel> coffeeList = await _context.Coffees.ToListAsync();
            foreach (var c in coffeeList)
            {
                _context.Entry(c).Reference("Country").Load();
                _context.Entry(c).Reference("Variety").Load();
                CoffeeViewModel cvm = new CoffeeViewModel
                {
                    Item = c
                };
                lcvm.Add(cvm);
            }

            return View(lcvm);
        }

        // GET: Coffee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoffeeViewModel cvm = new CoffeeViewModel();
            cvm.Item = await _context.Coffees.FirstOrDefaultAsync(m => m.Id == id);
            if (cvm == null)
            {
                return NotFound();
            }
            _context.Entry(cvm.Item).Reference("Country").Load();
            _context.Entry(cvm.Item).Reference("Variety").Load();
            return View(cvm);
        }

        // GET: Coffee/Create
        public IActionResult Create()
        {
            CoffeeViewModel vm = new CoffeeViewModel
            {
                Countries = new SelectList(_context.Countries.ToList(), "Id", "Name"),
                Varieties = new SelectList(_context.Varieties.ToList(), "Id", "Name")
            };

            return View(vm);
        }

        // POST: Coffee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Item")] CoffeeViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                CountryModel newCountry = _context.Countries.FirstOrDefault(c => c.Name == cvm.Item.Country.Name) ?? new CountryModel(null, cvm.Item.Country.Name);
                if (newCountry.Id == null)
                {
                    _context.Add(newCountry);
                }
                VarietyModel newVariety = _context.Varieties.FirstOrDefault(v => v.Name == cvm.Item.Variety.Name) ?? new VarietyModel(null, cvm.Item.Variety.Name);
                if (newVariety.Id == null)
                {
                    _context.Add(newVariety);
                }
                cvm.Item.Country = newCountry;
                cvm.Item.Variety = newVariety;
                _context.Add(cvm.Item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cvm);
        }

        // GET: Coffee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoffeeViewModel CoffeeVM = new CoffeeViewModel
            {
                Item = await _context.Coffees.FindAsync(id)
            };
            if (CoffeeVM.Item == null)
            {
                return NotFound();
            }
            _context.Entry(CoffeeVM.Item).Reference(c => c.Country).Load();
            _context.Entry(CoffeeVM.Item).Reference(v => v.Variety).Load();
            return View(CoffeeVM);
        }

        // POST: Coffee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Item")] CoffeeViewModel cvm)
        {
            if (id != cvm.Item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CountryModel newCountry = _context.Countries.FirstOrDefault(c => c.Name == cvm.Item.Country.Name) ?? new CountryModel(null, cvm.Item.Country.Name);
                    if (newCountry.Id == null)
                    {
                        _context.Add(newCountry);
                    }
                    VarietyModel newVariety = _context.Varieties.FirstOrDefault(v => v.Name == cvm.Item.Variety.Name) ?? new VarietyModel(null, cvm.Item.Variety.Name);
                    if (newVariety.Id == null)
                    {
                        _context.Add(newVariety);
                    }
                    cvm.Item.Country = newCountry;
                    cvm.Item.Variety = newVariety;
                    _context.Update(cvm.Item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeModelExists(cvm.Item.Id))
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
            return View(cvm);
        }

        // GET: Coffee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cvm = new CoffeeViewModel();
            cvm.Item = await _context.Coffees.FirstOrDefaultAsync(m => m.Id == id);
            if (cvm == null)
            {
                return NotFound();
            }
            _context.Entry(cvm.Item).Reference("Country").Load();
            _context.Entry(cvm.Item).Reference("Variety").Load();
            return View(cvm);
        }

        // POST: Coffee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffeeModel = await _context.Coffees.FindAsync(id);
            _context.Coffees.Remove(coffeeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeeModelExists(int id)
        {
            return _context.Coffees.Any(e => e.Id == id);
        }
    }
}
