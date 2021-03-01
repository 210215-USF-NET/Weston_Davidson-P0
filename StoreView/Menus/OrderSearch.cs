using System;
using StoreModel;
using StoreController;
using System.Collections.Generic;
using System.Collections;


namespace StoreView.Menus
{
    public class OrderSearch : IMenu
    {
        

        private IOrderBL _orderBL;
        private IOrderItemsBL _orderItemsBL;

        public OrderSearch(IOrderBL orderBL, IOrderItemsBL orderItemsBL){
            _orderBL = orderBL;
            _orderItemsBL = orderItemsBL;
        }

        public void Start(){
            Boolean stay = true;
            Console.WriteLine("Welcome to the order search system!");

            do{

            Console.WriteLine("Enter an order ID to view details about a specific order.");
            Console.WriteLine("Type in \"all\" to view a list of all orders.");
            Console.WriteLine("Type in \"exit\" to return to the manager menu.");



            String userInput = Console.ReadLine();
            
            switch(userInput){
                case "exit":
                //return to manager menu - value "true" should still be assigned to manager menu loop.
                stay = false;
                break;
                case "all":
                //return a list of all customers - BUILD IN METHOD TO INTERACT WITH BL
                GetAllOrders();
                break;
                default:
                //return specified string values of names retrieved from DB
                GetSearchedOrders(userInput);
                break;
            }

            } while(stay);


        }


                public void GetAllOrders(){
            LineSeparator line =  new LineSeparator();
            List<Order> orderList = _orderBL.GetOrders();
            foreach(Order order in orderList){
                line.LineSeparate();

                Console.WriteLine(order.OrdersWithCustomers());
                line.LineSeparate();
            }
            line.LineSeparate();
        }


        public void GetSearchedOrders(string searchTerm){
            
            int tracker = 0;

            LineSeparator line =  new LineSeparator();
            List<Order> orderList = _orderBL.GetOrders();
            Order singleOrderFound = new Order();
            List<OrderItem> itemsInOrder = new List<OrderItem>();
            foreach(Order order in orderList){

                if(order.Customer.FName.Contains(searchTerm) || order.Customer.LName.Contains(searchTerm) || order.OrderID.ToString().Contains(searchTerm)){
                    line.LineSeparate();
                    Console.WriteLine(order.OrdersWithCustomers());
                    tracker++;
                    if(tracker == 1){
                        itemsInOrder = _orderItemsBL.GetOrderItems(order.OrderID);
                        singleOrderFound = order;
                    }

                }

            }

            if (tracker == 0){
                line.LineSeparate();
                Console.WriteLine("No results found! Please double-check customer name spelling");
            }
            else if (tracker == 1){
                Console.WriteLine($"Single order found! Here are the specific details regarding order {singleOrderFound.OrderID}:");
                Console.WriteLine("Customer Info:");
                Console.WriteLine($"Customer Name: {singleOrderFound.Customer.FName} {singleOrderFound.Customer.LName}");
                foreach(OrderItem o in itemsInOrder){
                    line.LineSeparate();
                    Console.WriteLine($"| Product ID: {o.productID} | Product Quantity: {o.OrderItemsQuantity} |");

                }



            }

            line.LineSeparate();

        }



    }
}