using System;
using StoreView.Menus;
using StoreModel;
using StoreController;
using StoreData;
using StoreData.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;


namespace StoreView 
{

	class Program 
	{

		static void Main (string[] args)
		{
			//get the config file
			var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build(); 

			//set up db connection
			string connectionString = configuration.GetConnectionString("P0DB-REAL");
			DbContextOptions<P0Context> options = new DbContextOptionsBuilder<P0Context>()
			.UseSqlServer(connectionString)
			.Options;

			//using statement
			using var context = new P0Context(options);

			IMenu menu = new MainMenu(new CustomerBL(new CustomerRepoDB(context, new ShopMapper())), new ProductBL(new ProductRepoFile()), new LocationBL(new LocationRepoFile()), new OrderBL(new OrderRepoFile()));
			menu.Start(); 


		}
}
}