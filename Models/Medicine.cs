using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMedicineApp.Models
{
    public class Medicine
    {
        public int id { get; set; }
        public string MyProperty { get; set; }
        public string Manufacturer { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal discount { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpDate { get; set; }
        public string ImageUrl { get; set; }
        public int Status { get; set; }
    }
} 
