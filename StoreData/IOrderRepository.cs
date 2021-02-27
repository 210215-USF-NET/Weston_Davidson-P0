using StoreModel;
using System.Collections.Generic;
using System;

namespace StoreData
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();

        List<Order> GetOrdersWithCustomers();

        Order AddOrder(Order newOrder);


    }
}