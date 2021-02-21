namespace StoreModel
{
    public class Customer
    {
        string FName {get; set;}

        string LName {get; set;}

        int CustomerID {get; set;}


        string PasswordHash {get{return PasswordHash;} set{
            //TODO - create hashing algorithm in BL and call here
            //call busineslogic and return hash value, assign passwordHash to 
            PasswordHash = "This would be the hash generated for customer";

        }
        
        
        }

    }
}