using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class CustomerBL : ICustomerBL
    {
        private Random rand = new Random();

        private ICustomerRepository _repo;

        public CustomerBL(ICustomerRepository repo){
            _repo = repo;
        }

        




        public void AddCustomer(Customer newCustomer){
            _repo.AddCustomer(newCustomer);

        }

        public List<Customer> GetCustomers(){
            return _repo.GetCustomers();

        }


        public int GenerateID(){
            //this will need to be replaced with a way to check against existing DB values later on
            int CustomerID = RNG.RandomGen();
            return CustomerID;

        }
        
    }
}