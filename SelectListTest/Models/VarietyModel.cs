using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelectListTest.Models
{
    public class VarietyModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public VarietyModel() { }
        public VarietyModel(int? id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
