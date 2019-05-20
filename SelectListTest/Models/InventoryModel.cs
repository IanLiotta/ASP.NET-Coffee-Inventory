using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public CoffeeModel Coffee { get; set; }
        public VendorModel Vendor { get; set; }
        public decimal PricePerLbs { get; set; }
        public decimal LbsOnHand { get; set; }
    }
}
