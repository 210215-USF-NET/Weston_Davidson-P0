using System;
using StoreModel;
using StoreController;


namespace StoreView.Menus
{
    public class MainMenu : IMenu
    {
            private IMenu managerMenu;



        public MainMenu(ICustomerBL customerBL, IProductBL productBL, ILocationBL locationBL, IInventoryBL inventoryBL, IOrderBL orderBL, ICartBL cartBL, ICartProductsBL cartProductsBL, IOrderItemsBL orderItemsBL){



            //create required menu views in constructor, pass in required BL/DL connections
            managerMenu = new ManagerMenu(customerBL, productBL, locationBL, inventoryBL, orderBL, cartBL, cartProductsBL, orderItemsBL);
        }

        //could create a facade that's an interface that inherits f

            


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