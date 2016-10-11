using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSample.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CName { get; set; }
        public List<Product> Products { get; set; }
    }
}