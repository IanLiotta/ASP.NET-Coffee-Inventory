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
    public class CountryController : Controller
    {
        private readonly InventoryDbContext _context;

        public CountryController(InventoryDbContext context)
        {
            _context = context;
        }
     
        // GET: Country/List
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryModel>>> List()
        {
            return await _context.Countries.ToListAsync();
        }
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
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

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Country/Edit/5
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

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Country/Delete/5
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