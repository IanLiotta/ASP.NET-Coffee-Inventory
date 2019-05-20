using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class CoffeeViewModel
    {
        public CoffeeModel Item { get; set; }
        public SelectList Countries { get; set; }
        public SelectList Varieties { get; set; }
        public string TasteNotes { get; set; }
    }
}
