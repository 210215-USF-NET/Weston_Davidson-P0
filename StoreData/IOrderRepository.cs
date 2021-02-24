using StoreModel;
using System.Collections.Generic;
using System;

namespace StoreData
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
    }
}