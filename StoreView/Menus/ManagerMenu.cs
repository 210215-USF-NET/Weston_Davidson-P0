using System;
using StoreModel;
using StoreController;
using StoreData;

namespace StoreView.Menus
{
    
    public class ManagerMenu : IMenu
    {
        private ICustomerBL _customerBL;
        private IProductBL _productBL;
        private ILocationBL _locationBL;

        private IMenu customerSearch;
        private IMenu productSearch;

        public ManagerMenu(ICustomerBL customerBL, IProductBL productBL, ILocationBL locationBL){
            _customerBL = customerBL;
            _productBL = productBL;
            _locationBL = locationBL;

            //generate menus necessary for managermenu access
            customerSearch = new CustSearch(_customerBL);
            productSearch = new ProductSearch(_productBL);
        }

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
            Console.WriteLine("[5] Review Products");
            Console.WriteLine("[6] Add new Product");
            //place orders as manager

            Console.WriteLine("[7] Exit");

            String userInput = Console.ReadLine();

            switch(userInput){

                case "0":
                    try {
                        //BL Call - create customer -  WORKING :)
                        //still need to implement automatic customer ID assignment
                        CreateCustomer();
                    }
                    catch(Exception){
                        Console.WriteLine("Invalid Input");
                            
                        continue;
                    }
                    break;

                case "1":
                    customerSearch.Start();
                    break;

                case "2":
                        //BL Call - add inventory to store
                        AddInventory();
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
                        //search products
                        productSearch.Start();
                        break;
                case "6":
                        //add new product
                        AddProduct();
                        break;
                case "7":
                        //exit program
                        System.Environment.Exit(0);
                        break;

                default :
                Console.WriteLine("Not a valid menu option!");
                break;
            }
            } while(stay);



        }



        public void CreateCustomer(){
            Customer newCustomer = new Customer();


            Console.WriteLine("Enter Customer First Name: ");
            newCustomer.FName = Console.ReadLine();

            Console.WriteLine("Enter Customer Last Name: ");
            newCustomer.LName = Console.ReadLine();

            Console.WriteLine("Set Customer Account Default Password: ");

            newCustomer.PasswordHashSetter(Console.ReadLine());

            newCustomer.CustomerID = _customerBL.GenerateID();

            _customerBL.AddCustomer(newCustomer);
            Console.WriteLine($"Customer {newCustomer.FName} {newCustomer.LName} created successfully!");
        }


        public void AddProduct(){
            Product newProduct = new Product();
            
            newProduct.ProductID = _productBL.GenerateID();
            Console.WriteLine("Enter new Product Name:");
            newProduct.ProductName = Console.ReadLine();

            Console.WriteLine("Enter new Product Description:");
            newProduct.ProductDescription = Console.ReadLine();

            _productBL.AddProduct(newProduct);
            Console.WriteLine($"Product {newProduct.ProductName} With product ID {newProduct.ProductID} created successfully!");


        }


        public void AddInventory(){

        }
    }
}