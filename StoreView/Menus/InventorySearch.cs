using System;
using StoreModel;
using StoreController;
using System.Collections.Generic;
using System.Collections;

namespace StoreView.Menus
{
    public class InventorySearch : IMenu
    {
        private IInventoryBL _inventoryBL;

        public InventorySearch(IInventoryBL inventoryBL){
            _inventoryBL = inventoryBL;
        }

        public void Start()
        {
                        Boolean stay = true;
            Console.WriteLine("Welcome to inventory search!");

            do{

            Console.WriteLine("Enter an inventory name, product name, or location name to view a list of inventories associated with that name");
            Console.WriteLine("Type in \"all\" to view a list of all inventories across all locations");
            Console.WriteLine("Type in \"exit\" to return to the manager menu.");



            String userInput = Console.ReadLine();
            
            switch(userInput){
                case "exit":
                //return to manager menu - value "true" should still be assigned to manager menu loop.
                stay = false;
                break;
                case "all":
                //return a list of all customers - BUILD IN METHOD TO INTERACT WITH BL
                GetAllInventories();
                break;
                default:
                GetSearchedInventories(userInput);
                //return specified string values of store inventories
                //GetSearchedStoreInventories(userInput);
                break;
            }

            } while(stay);
        }


        public void GetAllInventories(){
            LineSeparator line = new LineSeparator();
            List<Inventory> inventoryList = _inventoryBL.GetInventory();
            foreach(Inventory x in inventoryList){
                line.LineSeparate();
                Console.WriteLine(x);
            }
            line.LineSeparate();

        }

        public void GetSearchedInventories(string searchTerm){
            int tracker = 0;
            LineSeparator line =  new LineSeparator();
            List<Inventory> customerList = _inventoryBL.GetInventory();
            foreach(Inventory x in customerList){
                
                if(x.InventoryName.Contains(searchTerm) || x.Location.LocationName.Contains(searchTerm) || x.Product.ProductName.Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(x);
                    tracker++;
                }
            }

            if (tracker == 0){
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check spelling. \nReminder: This search system is Case Sensitive :)");
            }

            line.LineSeparate();

            Console.WriteLine("Here are your results! Press enter to search again.");
            Console.ReadLine();

        }
    }
}