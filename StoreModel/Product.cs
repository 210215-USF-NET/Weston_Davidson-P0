namespace StoreModel
{
    public class Product
    {
        int ProductID {get; set;}

        string ProductName {get; set;}

        string ProductDescription {get; set;}


        //by tracking product location in product, we can easily determine where inventory should be added
        // depending on how this POCO gets set
        string ProductLocation {get; set;}


    }
}