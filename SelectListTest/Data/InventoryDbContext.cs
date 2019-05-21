using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelectListTest.Models;

namespace SelectListTest.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<VarietyModel> Varieties { get; set; }
        public DbSet<CoffeeModel> Coffees { get; set; }
        public DbSet<VendorModel> Vendors { get; set; }
        public DbSet<InventoryModel> Inventory { get; set; }
        public DbSet<SelectListTest.Models.RoastModel> Roasts { get; set; }
    }
}
