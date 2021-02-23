using System.IO;
using System.Collections.Generic;
using StoreModel;
using System.Text.Json;
using System;

namespace StoreData
{
    public class ProductRepoFile : IProductRepository
    {
        private string jsonString;
        private string filePath = "../ProductRepoFile.json";


        public Product AddProduct(Product newProduct){

            List<Product> productsFromFile = new List<Product>();

            productsFromFile = GetProducts();

            productsFromFile.Add(newProduct);

            jsonString = JsonSerializer.Serialize(productsFromFile);
            File.WriteAllText(filePath, jsonString);

            return newProduct;

        }


        public List<Product> GetProducts(){


            try{
                jsonString = File.ReadAllText(filePath);
            }
            catch(Exception){
                return new List<Product>();
            }

            return JsonSerializer.Deserialize<List<Product>>(jsonString);
        }

    }
}