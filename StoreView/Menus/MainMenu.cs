using System;
using StoreModel;
using StoreController;


namespace StoreView.Menus
{
    public class MainMenu : IMenu
    {
            private IMenu managerMenu;

            private ICustomerBL _customerBL;
            private IProductBL _productBL;
            private ILocationBL _locationBL;
            private IOrderBL _orderBL;

            private IInventoryBL _inventoryBL;

        public MainMenu(ICustomerBL customerBL, IProductBL productBL, ILocationBL locationBL, IInventoryBL inventoryBL, IOrderBL orderBL){
            _customerBL = customerBL;
            _productBL = productBL;
            _locationBL = locationBL;
            _orderBL = orderBL;
            _inventoryBL = inventoryBL;


            //create required menu views in constructor, pass in required BL/DL connections
            managerMenu = new ManagerMenu(_customerBL, _productBL, _locationBL, _inventoryBL, _orderBL);
        }


            


        public void Start(){
            Boolean stay = true;
            do{

                Console.WriteLine("Welcome to the store application! What sort of user are you?");
                Console.WriteLine("[0] Manager");
                Console.WriteLine("[1] Customer");
                Console.WriteLine("[2] Exit");

                String userInput = Console.ReadLine();

                switch (userInput){
                    case "0":
                    stay = false;
                    managerMenu.Start();
                    break;
                    case "1":
                    stay = false;
                    //client menu stuff
                    break;
                    case "2":
                    System.Environment.Exit(0);
                    break;
                    default :
                    Console.WriteLine("Not a valid menu option!");
                    break;
                    

                }



            } while (stay);

        }
    }
}