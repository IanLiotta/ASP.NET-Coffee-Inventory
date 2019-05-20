using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public InventoryModel Item { get; set; }
        public SelectList Coffees { get; set; }
        public SelectList Vendors { get; set; }
    }
}
