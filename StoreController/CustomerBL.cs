using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class CustomerBL : ICustomerBL
    {


        private ICustomerRepository _repo;

        public CustomerBL(ICustomerRepository repo){
            _repo = repo;
        }

        /*
        public string GenerateID(){

        }
        */


        public void AddCustomer(Customer newCustomer){
            _repo.AddCustomer(newCustomer);

        }

        public List<Customer> GetCustomers(){
            return _repo.GetCustomers();

        }
        
    }
}