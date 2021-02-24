using System;
using StoreView.Menus;
using StoreModel;
using StoreController;
using StoreData;

namespace StoreView 
{

	class Program 
	{

		static void Main (string[] args)
		{
		IMenu menu = new MainMenu(new CustomerBL(new CustomerRepoFile()), new ProductBL(new ProductRepoFile()), new LocationBL(new LocationRepoFile()), new OrderBL(new OrderRepoFile()));
		menu.Start(); 


		}
}
}