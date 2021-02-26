using System.Collections.Generic;
using System;

namespace StoreModel
{
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        //an order has a location, a customer, and a list of products

        //public List<Product> ProductsPurchased {get; set;}

        public Customer CustomerID { get; set; }

        public Location LocationID { get; set; }

        public Cart CartID { get; set; }

    }
}