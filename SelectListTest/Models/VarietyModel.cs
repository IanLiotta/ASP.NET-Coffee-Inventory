using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class VarietyModel
    {
        public int? Id { get; set; }
        [DisplayName("Variety")]
        public string Name { get; set; }
        public VarietyModel() { }
        public VarietyModel(int? id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
