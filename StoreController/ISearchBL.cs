namespace StoreController
{
    public interface ISearchBL
    {
        void getAll();

        void getSearched(string searchTerm);
    }
}