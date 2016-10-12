using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSample.Models
{
    public partial class ShoppingCart
    {
        ShoppingEntities storeDB = new ShoppingEntities();

        string ShoppingCartID { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartID = cart.GetCardId(context);
            return cart;
        }

        public void AddToCart(Product product)
        {
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.CartID == ShoppingCartID
                && c.ProductID == product.ProductID);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    ProductID = product.ProductID,
                    CartID = ShoppingCartID,
                    Count = 1
                };
                storeDB.Carts.Add(cartItem);
            }

            else
            {
                cartItem.Count++;
            }
            storeDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var CartItem = storeDB.Carts.Single(
                cart => cart.CartID == ShoppingCartID
                && cart.RecordID == id);

            int itemCount = 0;

            if(CartItem != null)
            {
                if (CartItem.Count > 1)
                {
                    CartItem.Count--;
                    itemCount = CartItem.Count;
                }
                else
                {
                    storeDB.Carts.Remove(CartItem);
                }
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(cart => cart.CartID == ShoppingCartID);
            foreach(var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            storeDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return storeDB.Carts.Where(
                cart => cart.CartID == ShoppingCartID).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CartID == ShoppingCartID
                          select (int?)cartItems.Count).Sum();
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.CartID == ShoppingCartID
                              select (int?)cartItems.Count *
                              cartItems.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductID = item.ProductID,
                    OrderID = order.OrderID,
                    UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };
                orderTotal += (item.Count * item.Product.Price);

                storeDB.OrderDetails.Add(orderDetail);
            }
            order.Total = orderTotal;

            storeDB.SaveChanges();
            EmptyCart();

            return order.OrderID;
        }

        public string GetCardId(HttpContextBase context)
        {
            if(context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            var ShoppingCart = storeDB.Carts.Where(
                c => c.CartID == ShoppingCartID);

            foreach(Cart item in ShoppingCart)
            {
                item.CartID = userName;
            }
            storeDB.SaveChanges();
        }
    }
}