namespace StoreView
{
    public class ConcreteMenuFactory : IAbstractMenuFactory
    {
        public IAbstractMenuA CreateMenuA(){
            return new ConcreteMenuA();
        }


    }
}