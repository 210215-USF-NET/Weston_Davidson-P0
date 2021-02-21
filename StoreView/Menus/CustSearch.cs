using System;
using StoreModel;
using StoreController;

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

            Console.WriteLine("Enter a customer name to view details about a specific customer.");
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
                Console.WriteLine("This would return a list of all customers");
                break;
                default:
                //return specified string values of names retrieved from DB
                Console.WriteLine($"This will return a list of all people matching search criteria {userInput}");
                break;
            }

            } while(stay);


        }
    }
}