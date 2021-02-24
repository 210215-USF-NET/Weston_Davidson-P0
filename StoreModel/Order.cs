using System.Collections.Generic;

namespace StoreModel
{
    public class Order
    {
        int OrderID {get; set;}

        int OrderDate {get; set;}

        //an order has a location, a customer, and a list of products

        public List<Product> ProductsPurchased {get; set;}

        public Customer CustomerID {get; set;}

        public Location Location {get; set;}
        
    }
}