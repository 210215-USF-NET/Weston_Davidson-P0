namespace StoreModel
{
    public class Inventory
    {
        public int InventoryID {get; set;}

        // each inventory has a product, and a store
        public Product ProductID {get; set;}
        public int ProductQuantity {get; set;}
        
        // inventory has a store
        public Location InventoryLocation {get; set;}



        //the inventory name should probably basically be the singluar product
        //that is contained in that inventory
        public string InventoryName {get; set;}

        

    }
}