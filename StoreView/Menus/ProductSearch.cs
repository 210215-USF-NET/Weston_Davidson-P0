using System;
using StoreModel;
using StoreController;
using System.Collections.Generic;
using System.Collections;
using StoreData;

namespace StoreView.Menus
{
    public class ProductSearch : IProductSearch
    {
        private IProductBL _productBL;
        private ICartProductsBL _cartProductsBL;

        public ProductSearch(IProductBL productBL, ICartProductsBL cartProductsBL)
        {
            _productBL = productBL;
            _cartProductsBL = cartProductsBL;
        }

        public void Start()
        {

            Boolean stay = true;
            Console.WriteLine("Welcome to the product search portal!");

            do
            {

                Console.WriteLine("Enter a product name to view details about a specific product.");
                Console.WriteLine("Type in \"all\" to view a list of all products");
                Console.WriteLine("Type in \"exit\" to return to the manager menu.");



                String userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        //return to manager menu - value "true" should still be assigned to manager menu loop.
                        stay = false;
                        break;
                    case "all":
                        //return a list of all customers - BUILD IN METHOD TO INTERACT WITH BL
                        GetAllProducts();
                        break;
                    default:
                        //return specified string values of names retrieved from DB
                        GetSearchedProducts(userInput);
                        break;
                }

            } while (stay);

        }

        public void Start(Location location, int cartID)
        {
            Boolean stay = true;

            do
            {

                Console.WriteLine("Enter a product name, or manufacturer to filter the list of products!.");
                Console.WriteLine("Once you find a product, specify quantity and confirm if you would like to add that product to the order.");
                Console.WriteLine("Type in \"all\" to view a list of all customers");
                Console.WriteLine("Type in \"exit\" to cancel product ordering process.");



                String userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        //return to manager menu - value "true" should still be assigned to manager menu loop.
                        stay = false;
                        break;
                    case "all":
                        //return a list of all customers
                        GetAllProducts();
                        break;
                    default:

                        GetFilteredProductsForProcessing(userInput, cartID);
                        break;
                }

            } while (stay);


        }
        public void GetAllProducts()
        {
            LineSeparator line = new LineSeparator();
            List<Product> productList = _productBL.GetProduct();
            foreach (Product product in productList)
            {
                line.LineSeparate();
                Console.WriteLine(product);
            }
            line.LineSeparate();
        }


        public void GetSearchedProducts(string searchTerm)
        {
            int tracker = 0;

            LineSeparator line = new LineSeparator();
            List<Product> productList = _productBL.GetProduct();
            foreach (Product product in productList)
            {
                if (product.ProductName.Contains(searchTerm) || product.Manufacturer.Contains(searchTerm) || product.ProductID.ToString().Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(product);
                    tracker++;
                }
            }

            if (tracker == 0)
            {
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check product spelling. \nThis system is Case Sensitive :)");
            }

            line.LineSeparate();

        }


        public void GetFilteredProductsForProcessing(string searchTerm, int cartID)
        {
            Product foundProduct = new Product();
            int tracker = 0;
            LineSeparator line = new LineSeparator();
            List<Product> productList = _productBL.GetProduct();
            foreach (Product product in productList)
            {
                if (product.ProductName.Contains(searchTerm) || product.Manufacturer.Contains(searchTerm) || product.ProductID.ToString().Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(product);
                    tracker++;
                    //for the first found customer, store in our foundcustomer object, but don't do it again
                    if(tracker == 1){
                        foundProduct.ProductID = product.ProductID;
                        foundProduct.ProductName = product.ProductName;
                        foundProduct.ProductDescription = product.ProductDescription;
                        foundProduct.Manufacturer = product.Manufacturer;
                        foundProduct.ProductPrice = product.ProductPrice;
                    }

                }

            }

            if (tracker == 0)
            {
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check customer name spelling. \nReminder: This search system is Case Sensitive :)");
            }
            //if the tracker only happened once, that means one customer with the matching value was found, so we pass that customer reference
            //back out to our manager system :)
            if (tracker == 1)
            {
                line.LineSeparate();
                Console.WriteLine("We have found one product from your search. Please see the details displayed above.");
                Console.WriteLine("Would you like to add this product to your cart?");
                Console.WriteLine("[0] Yes");
                Console.WriteLine("[1] No");
                switch (Console.ReadLine())
                {
                    case "0":
                    CartProducts cartProduct = new CartProducts();
                    Console.WriteLine("Please enter how many you would like to order: ");
                    cartProduct.ProductCount = Int32.Parse(Console.ReadLine());
                    cartProduct.CartID = cartID;
                    cartProduct.ProductID = foundProduct.ProductID;

                    _cartProductsBL.AddCartProduct(cartProduct);

                    Console.WriteLine("Product added to cart successfully!");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    


                    break;
                    case "1":
                    Console.WriteLine("Okay, please search again to find a different product. \nPress enter to continue.");
                    Console.ReadLine();
                    break;
                    default:
                    Console.WriteLine("This is not a valid menu option!");
                    break;
                }

            }

            line.LineSeparate();

        }

    }
}
