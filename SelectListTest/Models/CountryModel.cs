using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class CountryModel
    {
        public int? Id { get; set; }
        [DisplayName("Country")]
        public string Name { get; set; }
        public CountryModel() { }
        public CountryModel(int? id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
