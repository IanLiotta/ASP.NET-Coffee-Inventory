using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class CoffeeModel
    {
        [Required]
        public int Id { get; set; }
        public CountryModel Country { get; set; }
        public VarietyModel Variety { get; set; }
        public string TasteNotes { get; set; }
    }
}
