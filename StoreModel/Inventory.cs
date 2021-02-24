namespace StoreModel
{
    public class Inventory
    {
        public int InventoryID {get; set;}

        public int ProductQuantity {get; set;}
        
        //the inventory name should probably basically be the singluar product
        //that is contained in that inventory
        public string InventoryName {get; set;}

        

    }
}