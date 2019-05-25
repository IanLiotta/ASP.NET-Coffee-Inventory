using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class CoffeeModel
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Country")]
        public CountryModel Country { get; set; }
        [DisplayName("Variety")]
        public VarietyModel Variety { get; set; }
        [DisplayName("Tasting Notes")]
        public string TasteNotes { get; set; }
    }
}
