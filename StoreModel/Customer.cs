namespace StoreModel
{
    public class Customer
    {
        public int CustomerID {get; set;}

        public string FName {get; set;}

        public string LName {get; set;}

        public string Username {get; set;}



        private string passwordHash;

        /*
        public string PasswordHasGetter(){
            return passwordHash;
        }
        */

        public void PasswordHashSetter(string password){
                        //TODO - create hashing algorithm in BL and call here
            //call busineslogic and return hash value, assign passwordHash to 
            passwordHash = password;


        }

        public override string ToString()
        {
            
            return $"| First Name: {FName} | Last Name: {LName} | Customer ID: {CustomerID} |";
        }




    
    
    }

}
