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

        public int CustomerID { get; set; }

        public int LocationID { get; set; }

        public int CartID { get; set; }

        public Customer Customer {get; set;}



        public string OrdersWithCustomers(){
            return $"| Order ID: {OrderID} | Order Date: {OrderDate} | Customer Name: {Customer.FName} | Location ID: {LocationID}";
        }

        public override string ToString()
        {
            
            return $"| Order ID: {OrderID} | Order Date: {OrderDate} | Customer ID: {CustomerID} | Location ID: {LocationID}";
        }
    }
}