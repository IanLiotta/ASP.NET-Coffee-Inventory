using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public CoffeeModel Coffee { get; set; }
        public VendorModel Vendor { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerLbs { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LbsOnHand { get; set; }
    }
}
