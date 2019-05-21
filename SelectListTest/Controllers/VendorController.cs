using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelectListTest.Data;
using SelectListTest.Models;

namespace SelectListTest.Controllers
{
    public class VendorController : Controller
    {
        private readonly InventoryDbContext _context;

        public VendorController(InventoryDbContext context)
        {
            _context = context;
        }
        // GET: Vendor/List
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorModel>>> List()
        {
            return await _context.Vendors.ToListAsync();
        }
        // GET: Vendor
        public async Task<ActionResult<IEnumerable<VendorModel>>> Index()
        {
            var vendorList = await _context.Vendors.ToListAsync();
            return View(vendorList);
        }

        // GET: Vendor/Details/5
        public ActionResult Details(int id)
        {
            var vendor = _context.Vendors.FirstOrDefault(i => i.Id == id);
            return View(vendor);
        }

        // GET: Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VendorModel newVendor)
        {
            try
            {
                _context.Add(newVendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Vendor/Edit/5
        public ActionResult Edit(int id)
        {
            var vendor = _context.Vendors.FirstOrDefault(i => i.Id == id);
            return View(vendor);
        }

        // POST: Vendor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VendorModel vendor)
        {
            try
            {
                _context.Vendors.Update(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Vendor/Delete/5
        public ActionResult Delete(int id)
        {
            var vendor = _context.Vendors.FirstOrDefault(i => i.Id == id);
            return View(vendor);
        }

        // POST: Vendor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(VendorModel vendor)
        {
            try
            {
                _context.Vendors.Remove(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}