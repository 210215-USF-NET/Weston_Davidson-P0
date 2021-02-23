
using System.Collections.Generic;
using StoreModel;
using System;

namespace StoreData
{
    
    public interface IProductRepository
    {
        List<Product> GetProducts();

        Product AddProduct(Product newProduct);
    }
}