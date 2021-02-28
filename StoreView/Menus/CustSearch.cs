using System;
using StoreModel;
using StoreController;
using System.Collections.Generic;
using System.Collections;

namespace StoreView.Menus
{
    public class CustSearch : ICustSearch
    {

        private ICustomerBL _customerBL;

        public CustSearch(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }

        public void Start()
        {
            Boolean stay = true;
            Console.WriteLine("Welcome to customer search!");

            do
            {

                Console.WriteLine("Enter a customer first name, last name, or ID to view details about a specific customer.");
                Console.WriteLine("Type in \"all\" to view a list of all customers");
                Console.WriteLine("Type in \"exit\" to return to the manager menu.");



                String userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        //return to manager menu - value "true" should still be assigned to manager menu loop.
                        stay = false;
                        break;
                    case "all":
                        //return a list of all customers - BUILD IN METHOD TO INTERACT WITH BL
                        GetAllCustomers();
                        break;
                    default:
                        //return specified string values of names retrieved from DB
                        GetSearchedCustomers(userInput);
                        break;
                }

            } while (stay);


        }

        public void Start(Customer retrievedCustomer)
        {
            Boolean stay = true;

            do
            {

                Console.WriteLine("Enter a customer first name, last name, or ID to filter down to a specific customer.");
                Console.WriteLine("Once you find a customer, confirm if this is the correct customer for this order.");
                Console.WriteLine("Type in \"all\" to view a list of all customers");
                Console.WriteLine("Type in \"exit\" to cancel product ordering process.");



                String userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        //return to manager menu - value "true" should still be assigned to manager menu loop.
                        stay = false;
                        break;
                    case "all":
                        //return a list of all customers - BUILD IN METHOD TO INTERACT WITH BL
                        GetAllCustomers();
                        break;
                    default:
                        //return specified string values of names retrieved from DB
                        GetFilteredCustomersForProcessing(userInput, ref retrievedCustomer, ref stay);
                        break;
                }

            } while (stay);


        }


        public void GetAllCustomers()
        {
            LineSeparator line = new LineSeparator();
            List<Customer> customerList = _customerBL.GetCustomers();
            foreach (Customer customer in customerList)
            {
                line.LineSeparate();
                Console.WriteLine(customer);
            }
            line.LineSeparate();
        }


        public void GetSearchedCustomers(string searchTerm)
        {

            int tracker = 0;
            LineSeparator line = new LineSeparator();
            List<Customer> customerList = _customerBL.GetCustomers();
            foreach (Customer customer in customerList)
            {
                if (customer.FName.Contains(searchTerm) || customer.LName.Contains(searchTerm) || customer.CustomerID.ToString().Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(customer);
                    tracker++;

                }

            }

            if (tracker == 0)
            {
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check customer name spelling. \nReminder: This search system is Case Sensitive :)");
            }

            line.LineSeparate();

        }

        public void GetFilteredCustomersForProcessing(string searchTerm, ref Customer resultingCustomer, ref bool stay)
        {

            int tracker = 0;
            LineSeparator line = new LineSeparator();
            List<Customer> customerList = _customerBL.GetCustomers();
            foreach (Customer customer in customerList)
            {
                if (customer.FName.Contains(searchTerm) || customer.LName.Contains(searchTerm) || customer.CustomerID.ToString().Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(customer);
                    tracker++;
                    //for the first found customer, store in our foundcustomer object, but don't do it again
                    if(tracker == 1){
                        resultingCustomer.FName = customer.FName;
                        resultingCustomer.LName = customer.LName;
                        resultingCustomer.CustomerID = customer.CustomerID;
                        resultingCustomer.Username = customer.Username;
                        resultingCustomer.PasswordHash = customer.PasswordHash;
                    }

                }

            }

            if (tracker == 0)
            {
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check customer name spelling. \nReminder: This search system is Case Sensitive :)");
            }
            //if the tracker only happened once, that means one customer with the matching value was found, so we pass that customer reference
            //back out to our manager system :)
            if (tracker == 1)
            {
                line.LineSeparate();
                Console.WriteLine("We have found one customer with the details displayed above.");
                Console.WriteLine("Is this the correct customer?");
                Console.WriteLine("[0] Yes");
                Console.WriteLine("[1] No");
                switch (Console.ReadLine())
                {
                    case "0":
                    stay = false;
                    break;
                    case "1":
                    Console.WriteLine("Okay, please search again to find the correct customer. \nPress enter to continue.");
                    Console.ReadLine();
                    break;
                    default:
                    Console.WriteLine("This is not a valid menu option!");
                    break;
                }
                
            }

            line.LineSeparate();

        }

    }
}