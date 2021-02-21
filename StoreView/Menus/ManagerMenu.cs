using System;

namespace StoreView.Menus
{
    
    public class ManagerMenu : IMenu
    {

        IMenu CustomerSearch = new CustSearch();
        public void Start()
        {
            Boolean stay = true;

            Console.WriteLine("Welcome, manager!");

            do{
            Console.WriteLine("What would you like to do?");

            Console.WriteLine("[0] Add a new Customer");
            Console.WriteLine("[1] Search for Customers");
            Console.WriteLine("[2] Add Inventory to Store");
            Console.WriteLine("[3] Review Orders");
            Console.WriteLine("[4] Review Inventory");
            Console.WriteLine("[5] Exit");

            String userInput = Console.ReadLine();

            switch(userInput){

                case "0":
                    try {
                        //BL Call - create customer
                        //CreateCustomer();
                    }
                    catch(Exception){
                        Console.WriteLine("Invalid Input");
                            
                        continue;
                    }
                    break;

                case "1":
                    //CustSearch.Start();
                    stay = false;
                    break;

                case "2":
                        //BL Call - add inventory to store
                        //AddInventory();
                        break;
                case "3":
                        //review orders
                        // menu call - take to orders menu
                        //OrderSearch.Start();
                        stay = false;
                        break;
                case "4":
                        //review inventory
                        // menu call - take to inventory menu
                        //InventorySearch.Start();
                        stay = false;
                        break;
                case "5":
                        //exit program
                        System.Environment.Exit(0);
                        break;

                default :
                Console.WriteLine("Not a valid menu option!");
                break;
            }
            } while(stay);



        }
    }
}