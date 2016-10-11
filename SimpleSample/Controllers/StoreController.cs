using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSample.Models;

namespace SimpleSample.Controllers
{
    public class StoreController : Controller
    {
        ShoppingEntities storeDB = new ShoppingEntities();
        // GET: Store
        public ActionResult Index()
        {
            //var categories = new List<Category>
            //{
            //    new Category {CName = "Home Appliances" },
            //    new Category {CName = "Mobile Phones" },
            //    new Category {CName = "Cameras" }

            //};
            var categories = storeDB.Categories.ToList();
            return View(categories);
        }

        public ActionResult Browse(string category)
        {
            if(category == null)
            { category = "Camera"; }
             
            //var cat = new Category { CName = category };
            var catModel = storeDB.Categories.Include("Products").
                Single(g => g.CName == category);
            return View(catModel);
            
        }

        public ActionResult Details(int id)
        {
            //var product = new Product { Name = "Nikon D5300", Description = "DSLR Camera", Price = 32000 };
            var product = storeDB.Products.Find(id);
            return View(product);
        }
    }
}