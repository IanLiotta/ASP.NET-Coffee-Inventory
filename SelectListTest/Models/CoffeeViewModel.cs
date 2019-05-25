using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class CoffeeViewModel
    {
        public CoffeeModel Item { get; set; }
        [DisplayName("Countries")]
        public SelectList Countries { get; set; }
        [DisplayName("Varieties")]
        public SelectList Varieties { get; set; }
        public string TasteNotes { get; set; }
    }
}
