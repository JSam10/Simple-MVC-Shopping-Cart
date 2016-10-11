using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSample.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public Category Category { get; set; }
    }
}