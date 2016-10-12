using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleSample.Models
{
    [Bind(Exclude = "ProductID")]
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Product Name is required")]
        [DisplayName("Product")]
        public string Name { get; set; }

        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        //[ForeignKey("CategoryID")]
        
        public virtual Category Category { get; set; }
    }
}