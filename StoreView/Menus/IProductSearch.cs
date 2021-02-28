using System;
using StoreModel;

namespace StoreView.Menus
{
    public interface IProductSearch
    {
        void Start();
        void Start(Location location, int cartID);
    }
}