using System;
using StoreModel;
using StoreController;


namespace StoreView.Menus
{
    public class MainMenu : IMenu
    {
            private IMenu managerMenu;

            private ICustomerBL _customerBL;

        public MainMenu(ICustomerBL customerBL){
            _customerBL = customerBL;

            //create required menu views in constructor, pass in required BL/DL connections
            managerMenu = new ManagerMenu(_customerBL);
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
                    default :
                    Console.WriteLine("Not a valid menu option!");
                    break;
                    

                }



            } while (stay);

        }
    }
}