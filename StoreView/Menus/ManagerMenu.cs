using System;
using StoreModel;
using StoreController;
using StoreData;
using System.Collections.Generic;

namespace StoreView.Menus
{
    
    public class ManagerMenu : IMenu
    {
        private ICustomerBL _customerBL;
        private IProductBL _productBL;
        private ILocationBL _locationBL;
        private IOrderBL _orderBL;
        private IInventoryBL _inventoryBL;

        private ICartBL _cartBL;

        private ICartProductsBL _cartProductsBL;

        private ICustSearch customerSearch;
        private IProductSearch productSearch;
        private IMenu inventorySearch;
        private IMenu orderSearch;

        public ManagerMenu(ICustomerBL customerBL, IProductBL productBL, ILocationBL locationBL, IInventoryBL inventoryBL, IOrderBL orderBL, ICartBL cartBL, ICartProductsBL cartProductsBL){
            _customerBL = customerBL;
            _productBL = productBL;
            _locationBL = locationBL;
            _orderBL = orderBL;
            _inventoryBL = inventoryBL;
            _cartBL = cartBL;
            _cartProductsBL = cartProductsBL;

            //generate menus necessary for managermenu access
            customerSearch = new CustSearch(_customerBL);
            productSearch = new ProductSearch(_productBL, _cartProductsBL);
            inventorySearch = new InventorySearch(_inventoryBL);
            orderSearch = new OrderSearch(_orderBL);
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
            Console.WriteLine("[7] Place order for Customer");
            //place orders as manager

            Console.WriteLine("[8] Exit");

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
                        orderSearch.Start();
                        break;
                case "4":
                        //review inventory
                        // menu call - take to inventory menu
                        inventorySearch.Start();
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
                        PlaceOrder();
                        break;
                case "8":
                        //exit program
                        System.Environment.Exit(0);
                        break;

                default :
                Console.WriteLine("Not a valid menu option!");
                break;
            }
            } while(stay);



        }

        public void PlaceOrder(){
            Customer customer = new Customer();

            customerSearch.Start(customer);



            //we have the customer
            //we need the location next
            Boolean stay = true;
            Location location = new Location();

            while(stay){
            Console.WriteLine("Please select customer/store location");
            Console.WriteLine("[0] Tampa");
            Console.WriteLine("[1] Orlando");
            string userInput = Console.ReadLine();
            switch (userInput){
                case "0":
                location = _locationBL.GetSpecifiedLocation(20000);
                stay = false;
                break;
                case "1":
                location = _locationBL.GetSpecifiedLocation(20001);
                stay = false;
                break;

                default:
                Console.WriteLine("Not a valid menu option!");

                break;
            }
            Console.WriteLine(location);

            }

            //Console.WriteLine(customer);
            //now, with both a customer and location, we can create a cart OR call a cart
            //if the customer's cart already exists, it will use that cart
            
            Cart cart = _cartBL.FindCart(customer.CustomerID);

            //THIS is where we would want to call our product search menu
            // we want to basically run this, then on complete, create a new cartproduct object
            // we can check against inventory amount here!!!
            productSearch.Start(location, cart.CartID);
            Product product = new Product();


            /* add soon
            List<CartProducts> cartProducts = _cartProductsBL.FindCartProducts(customer.CustomerID, product.productID, productCount); 

            foreach(CartProducts p in cartProducts){
                Console.WriteLine(p);
            }
            */


            //now that we have a cart, we need to find products
            //then add them to a new cartproducts table so the cart
            //can reference them
            //we will call cartproduct BL to create a new cartproduct
            //every time something is added to the inventory.
            //then, we can return a list of cartproducts after?



            //then create an order when products/total are ready!


        }

        public void CreateCustomer(){
            Customer newCustomer = new Customer();


            Console.WriteLine("Enter Customer First Name: ");
            newCustomer.FName = Console.ReadLine();

            Console.WriteLine("Enter Customer Last Name: ");
            newCustomer.LName = Console.ReadLine();

            Console.WriteLine("Create a username for the customer: ");
            newCustomer.Username = Console.ReadLine();

            Console.WriteLine("Set Customer Account Default Password: ");
            newCustomer.PasswordHash = Console.ReadLine();
            //newCustomer.PasswordHashSetter(Console.ReadLine());

            //newCustomer.CustomerID = _customerBL.GenerateID();

            _customerBL.AddCustomer(newCustomer);

            Console.WriteLine($"Customer {newCustomer.FName} {newCustomer.LName} created successfully!");
        }


        public void AddProduct(){
            Product newProduct = new Product();
            
            //newProduct.ProductID = _productBL.GenerateID();
            Console.WriteLine("Enter new Product Name:");
            newProduct.ProductName = Console.ReadLine();

            Console.WriteLine("Enter new Product Description:");
            newProduct.ProductDescription = Console.ReadLine();

            Console.WriteLine("Enter product manufacturer: ");
            newProduct.Manufacturer = Console.ReadLine();
            Console.WriteLine("Enter Product Price");
            newProduct.ProductPrice = Decimal.Parse(Console.ReadLine());

            _productBL.AddProduct(newProduct);
            Console.WriteLine($"Product {newProduct.ProductName} created successfully!");


        }

        public void AddInventory(){
            Location trackedLocation = new Location();
            Inventory newInventory = new Inventory();
            Product newProduct = new Product();


            Console.WriteLine("Please enter the appropriate information to update a store's inventory");

            Console.WriteLine("Enter Location Name: ");
            

            
            trackedLocation = _locationBL.FilterLocationByName(Console.ReadLine());
            if (trackedLocation.LocationID == 0){
                Console.WriteLine("That's not a location Name :( please try again!");
                Console.WriteLine("Press Enter to Continue.");
                Console.ReadLine();
                return;
            }
            else
            {
                newInventory.InventoryLocation = trackedLocation.LocationID;
            }

            Console.WriteLine("Create a name for your inventory: ");
            newInventory.InventoryName=Console.ReadLine();

            Console.WriteLine("Please enter a product name to store in this inventory: ");
            newProduct = _productBL.GetFilteredProduct(Console.ReadLine());

            if (newProduct.ProductName == null){
                Console.WriteLine("This product does not exist in our system. Please try again :(");
                return;   
            }
            newInventory.ProductID = newProduct.ProductID;

            Console.WriteLine($"how many {newProduct.ProductName} items should be added to this inventory?");

            newInventory.ProductQuantity = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Great! the {trackedLocation.LocationName} location has been updated with an inventory of {newInventory.ProductQuantity} {newProduct.ProductName}");

            _inventoryBL.AddInventory(newInventory);
            Console.WriteLine("Inventory update successful! Press enter to continue.");
            Console.ReadLine();






            //Console.WriteLine(newInventory.InventoryLocation);
            


        }
    }
}