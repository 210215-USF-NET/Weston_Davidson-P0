using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;


namespace StoreController
{
    public class ProductBL : IProductBL
    {

        
        private IProductRepository _repo;

        public ProductBL(IProductRepository repo){
            _repo = repo;
        }
        public int GenerateID(){
            //this will need to be replaced with a way to check against existing DB values later on
            int productId = RNG.RandomGen();
            return productId;

        }

        public void AddProduct(Product newProduct){
            _repo.AddProduct(newProduct);
        }

        public List<Product> GetProduct(){
            return _repo.GetProducts();
        }


        
    }
}