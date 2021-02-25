using Entity = StoreData.Entities;
using Model = StoreModel;
using System.Linq;
namespace StoreData
{
    public class ShopMapper : IMapper
    {
        public Model.Cart ParseCart(Entities.Cart cart)
        {
            throw new System.NotImplementedException();
        }

        public Entity.Cart ParseCart(StoreModel.Cart cart)
        {
            throw new System.NotImplementedException();
        }

        public Model.CartProducts ParseCartProduct(Entity.Cartproduct cartproduct)
        {
            throw new System.NotImplementedException();
        }

        public Entity.Cartproduct ParseCartProduct(Model.CartProducts cartproduct)
        {
            throw new System.NotImplementedException();
        }

        public Model.Customer ParseCustomer(Entities.Customer customer)
        {
            return new Model.Customer
            {
                FName = customer.CustomerFname,
                LName = customer.CustomerLname,
                Username = customer.CustomerUsername,
                PasswordHash = customer.CustomerPasswordhash,
                CustomerID = customer.CustomerId
                //Carts = ParseCart(customer.Carts.First());
                //do i need to return lists of carts/orders? I'm not sure yet

            };
        }

        public Entity.Customer ParseCustomer(StoreModel.Customer customer)
        {
            return new Entity.Customer
            {
                CustomerFname = customer.FName,
                CustomerLname = customer.LName,
                CustomerUsername = customer.Username,
                CustomerPasswordhash = customer.PasswordHash
                //do i need to return lists of carts/orders? I'm not sure yet
                
            };
        }

        public Model.Inventory ParseInventory(Entities.Inventory inventory)
        {
            throw new System.NotImplementedException();
        }

        public Entity.Inventory ParseInventory(StoreModel.Inventory inventory)
        {
            throw new System.NotImplementedException();
        }

        public Model.Location ParseLocation(Entities.Location location)
        {
            throw new System.NotImplementedException();
        }

        public Entity.Location ParseLocation(StoreModel.Location location)
        {
            throw new System.NotImplementedException();
        }

        public Model.Order ParseOrder(Entities.Order order)
        {
            throw new System.NotImplementedException();
        }

        public Entity.Order ParseOrder(StoreModel.Order order)
        {
            throw new System.NotImplementedException();
        }

        public Model.Product ParseProduct(Entities.Product product)
        {
            throw new System.NotImplementedException();
        }

        public Entity.Product ParseProduct(StoreModel.Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}