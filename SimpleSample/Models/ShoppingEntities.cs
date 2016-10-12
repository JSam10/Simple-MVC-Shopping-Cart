using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleSample.Models
{
    public class ShoppingEntities : DbContext
    {
        public ShoppingEntities() : base("name = ShoppingEntities")
        {
            Database.SetInitializer<ShoppingEntities>(new DatabaseInitializer());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}