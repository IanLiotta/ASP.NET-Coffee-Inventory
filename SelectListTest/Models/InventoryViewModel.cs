using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class InventoryViewModel
    {
        public int ItemId { get; set; }
        [DisplayName("Country and Variety")]
        public int CoffeeId { get; set; }
        [DisplayName("Country and Variety")]
        public string CoffeeFullName { get; set; }
        [DisplayName("Vendor")]
        public int VendorId { get; set; }
        [DisplayName("Vendor")]
        public string VendorName { get; set; }
        [DisplayName("Price per Pound")]
        [DataType(DataType.Currency)]
        public decimal PricePerLbs { get; set; }
        [DisplayName("Amount on Hand (lbs)")]
        public decimal LbsOnHand { get; set; }
        [DisplayName("Roast Type")]
        public int RoastId { get; set; }
        [DisplayName("Roast Type")]
        public string RoastName { get; set; }
        public SelectList Coffees { get; set; }
        public SelectList Vendors { get; set; }
        public SelectList Roasts { get; set; }
    }
}
