using System;
namespace StoreView
{
    public class ClientSelector
    {
        public void MenuStart(){

            ClientMethod(new ConcreteMenuFactory());

        }

        public void ClientMethod(IAbstractMenuFactory factory){
            var menuA = factory.CreateMenuA();

            Console.WriteLine(menuA.UsefulFunctionA());
        }
    }
}