using System;
using StoreView.Menus;

namespace StoreView 
{

	class Program 
	{

		static void Main (string[] args)
		{
		IMenu menu = new MainMenu();
		menu.Start(); 


		}
}
}