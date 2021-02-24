using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class OrderBL:IOrderBL
    {
        private IOrderRepository _repo;

        public OrderBL(IOrderRepository repo){
            _repo = repo;
        }

        public List<Order> GetOrders(){
            return _repo.GetOrders();
        }


    }
}