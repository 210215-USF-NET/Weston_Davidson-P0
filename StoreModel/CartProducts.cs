namespace StoreModel
{
    public class CartProducts
    {

        public int CartProductsID {get; set;}
        //cartproducts are the combination of the cart ID they are held in
        //and the product ID being added


        public Cart CartID {get; set;}

        public Product ProductID{get; set;}

    }
}