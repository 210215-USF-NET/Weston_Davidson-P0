using System.Collections.Generic;
using System;
using StoreModel;

namespace StoreController
{
    public interface IOrderBL
    {
        List<Order> GetOrders();
    }
}