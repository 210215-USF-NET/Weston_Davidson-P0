using System;
using StoreModel;

namespace StoreView.Menus
{
    public interface ICustSearch
    {
        void Start();
        void Start(Customer customer);
    }
}