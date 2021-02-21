using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public interface ICustomerBL
    {
        
        int GenerateID();
        

        void AddCustomer(Customer newCustomer);

        List<Customer> GetCustomers();

    }
}