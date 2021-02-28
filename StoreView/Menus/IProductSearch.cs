using System;
using StoreModel;
using System.Collections.Generic;

namespace StoreView.Menus
{
    public interface IProductSearch
    {
        void Start();
        void Start(Location location, int cartID, List<Inventory> inventories);
    }
}