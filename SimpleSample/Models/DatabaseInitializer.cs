using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleSample.Models
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<ShoppingEntities>
    {
        public override void InitializeDatabase(ShoppingEntities context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        protected override void Seed(ShoppingEntities context)
        {
            
            IList<Category> defaultCategories = new List<Category>();
            IList<Product> defaultProducts = new List<Product>();

            defaultCategories.Add(new Category() { CName = "Speakers" });
            defaultCategories.Add(new Category() { CName = "Peripherals" });
            defaultCategories.Add(new Category() { CName = "Cameras" });
            defaultCategories.Add(new Category() { CName = "Mobile Phones" });
            defaultCategories.Add(new Category() { CName = "Home Appliances" });


            defaultProducts.Add(new Product() { Name = "Marshall Acton Bluetooth Speakers", Description = "Powerful, elegant, wireless", Price = 24000, Category = defaultCategories.FirstOrDefault(d => d.CName == "Speakers") });
            defaultProducts.Add(new Product() { Name = "iPhone 7", Description = "Really? Who needs a desciption for this?!", Price = 90000, Category = defaultCategories.FirstOrDefault(d => d.CName == "Mobile Phones") });
            defaultProducts.Add(new Product() { Name = "Google Pixel C", Description = "Really? Who needs a desciption for this?!", Price = 70000, Category = defaultCategories.FirstOrDefault(d => d.CName == "Mobile Phones") });
            defaultProducts.Add(new Product() { Name = "Mi4i", Description = "Xiaomi's newest", Price = 12000, Category = defaultCategories.FirstOrDefault(d => d.CName == "Mobile Phones") });
            defaultProducts.Add(new Product() { Name = "Nikon D5300", Description = "Comes with Dual Lens lens-kit", Price = 32000, Category = defaultCategories.FirstOrDefault(d => d.CName == "Cameras") });
            defaultProducts.Add(new Product() { Name = "Canon 70D", Description = "Canon's new Entry-level DSLR", Price = 20000, Category = defaultCategories.FirstOrDefault(d => d.CName == "Cameras") });
            defaultProducts.Add(new Product() { Name = "Philips Blender", Description = "Handy Hand-blender", Price = 5000, Category = defaultCategories.FirstOrDefault(d => d.CName == "Home Appliances") });
            defaultProducts.Add(new Product() { Name = "Mi 2000 mAh Power Bank", Description = "Portable Charger", Price = 2000, Category = new Category() { CName = "Miscellaneous" } });

            

            foreach(Category cg in defaultCategories)
            {
                context.Categories.Add(cg);
            }
            foreach (Product pd in defaultProducts)
            {
                context.Products.Add(pd);
            }
            base.Seed(context);
        }
    }
}