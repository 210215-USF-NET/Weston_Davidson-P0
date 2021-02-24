using System;
using StoreModel;
using StoreController;
using System.Collections.Generic;
using System.Collections;
using StoreData;

namespace StoreView.Menus
{
    public class ProductSearch : IMenu
    {
        private IProductBL _productBL;

        public ProductSearch(IProductBL productBL)
        {
            _productBL = productBL;
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
                if (product.ProductName.Contains(searchTerm))
                {
                    line.LineSeparate();
                    Console.WriteLine(product);
                }
            }

            if (tracker == 0)
            {
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check customer name spelling");
            }

            line.LineSeparate();

        }

    }
}
