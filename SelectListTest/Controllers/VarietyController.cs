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
    public class VarietyController : Controller
    {
        private readonly InventoryDbContext _context;

        public VarietyController(InventoryDbContext context)
        {
            _context = context;
        }
        // GET: Variety/List
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VarietyModel>>> List()
        {
            return await _context.Varieties.ToListAsync();
        }
        // GET: Variety
        public ActionResult Index()
        {
            return View();
        }

        // GET: Variety/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Variety/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Variety/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Variety/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Variety/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Variety/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Variety/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}