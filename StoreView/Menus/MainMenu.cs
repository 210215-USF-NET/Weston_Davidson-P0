using System;

namespace StoreView.Menus
{
    public class MainMenu : IMenu
    {
        
            //instantiate additional menus on main menu load

            IMenu ManagerMenu = new ManagerMenu();



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
                    ManagerMenu.Start();
                    break;
                    default :
                    Console.WriteLine("Not a valid menu option!");
                    break;
                    

                }



            } while (stay);

        }
    }
}