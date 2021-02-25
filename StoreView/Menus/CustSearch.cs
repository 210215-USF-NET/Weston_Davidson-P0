using System;
using StoreModel;
using StoreController;
using System.Collections.Generic;
using System.Collections;

namespace StoreView.Menus
{
    public class CustSearch : IMenu
    {

        private ICustomerBL _customerBL;

        public CustSearch(ICustomerBL customerBL){
            _customerBL = customerBL;
        }

        public void Start(){
            Boolean stay = true;
            Console.WriteLine("Welcome to customer search!");

            do{

            Console.WriteLine("Enter a customer first name, last name, or ID to view details about a specific customer.");
            Console.WriteLine("Type in \"all\" to view a list of all customers");
            Console.WriteLine("Type in \"exit\" to return to the manager menu.");



            String userInput = Console.ReadLine();
            
            switch(userInput){
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

            } while(stay);


        }


        public void GetAllCustomers(){
            LineSeparator line =  new LineSeparator();
            List<Customer> customerList = _customerBL.GetCustomers();
            foreach(Customer customer in customerList){
                line.LineSeparate();
                Console.WriteLine(customer);
            }
            line.LineSeparate();
        }


        public void GetSearchedCustomers(string searchTerm){
            
            int tracker = 0;
            LineSeparator line =  new LineSeparator();
            List<Customer> customerList = _customerBL.GetCustomers();
            foreach(Customer customer in customerList){
                if(customer.FName.Contains(searchTerm) || customer.LName.Contains(searchTerm) || customer.CustomerID.ToString().Contains(searchTerm)){
                    line.LineSeparate();
                    Console.WriteLine(customer);
                    tracker++;
                }
            }

            if (tracker == 0){
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check customer name spelling. \nReminder: This search system is Case Sensitive :)");
            }

            line.LineSeparate();

        }

    }
}