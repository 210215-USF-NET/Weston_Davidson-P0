namespace StoreModel
{
    public class Location
    {

        public string LocationName {get; set;}

        public int LocationID {get; set;}

        public string Address {get; set;}


        public override string ToString()
        {
            return $"| Location ID: {LocationID} | Name: {LocationName} | Address: {Address} |";
        }
    }
}