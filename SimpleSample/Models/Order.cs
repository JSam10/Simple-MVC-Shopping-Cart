using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSample.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails{ get; set; }
    }
}