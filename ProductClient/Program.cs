using System;
using System.Collections.Generic;
using System.Linq;
namespace ProductClient
{
    public class Program
    {
        static void Main()
        {           
            consoleMenu();
        }

        /// <summary>
        /// Method to print the menu and view and edit products
        /// </summary>
        static void consoleMenu()
        {
            bool exit = false;
            while (!exit)
            {
                GreenForeground("Menu: ");
                Console.WriteLine("Enter your choice: (1, 2, 3 or 4)");
                Console.WriteLine("1. View Products List");
                Console.WriteLine("2. View Products Details");
                Console.WriteLine("3. Edit Products Details");
                Console.WriteLine("4. To Exit the Program");

                switch (Console.ReadLine())
                {
                    case "1":
                        viewProductList();
                        break;
                    case "2":
                        viewProductDetails();
                        break;
                    case "3":
                        editProductDetails();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid number ");
                        break;
                }
            }
        }

        /// <summary>
        /// Method to view the products list using service client
        /// </summary>
        static void viewProductList()
        {
            //Intialise service client
            var client = new NorthwindService.NorthwindServiceClient();

            GreenForeground("Products List: ");

            var products = client.GetProducts();
            
            foreach (var pName in products)
            {
                var productData = client.GetProductData(pName);
                Console.WriteLine($"{productData.ProductName}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Method to view the product details using service client
        /// </summary>
        static void viewProductDetails()
        {
            //Intialise service client
            var client = new NorthwindService.NorthwindServiceClient();

            Console.WriteLine("Enter name of Product from the list to view all details");
            string name = Console.ReadLine();

            if(name != string.Empty)
            {
                GreenForeground("Product Details: ");
                var productData = client.GetProductData(name);
                if (productData != null)
                {
                    GreenForeground("| Product Name       | Quantity Per Unit |");
                    Console.WriteLine($"| {productData.ProductName,-18} | {productData.QuantityPerUnit,-17} |");
                }
                else
                {
                    Console.WriteLine("Product could not found.");
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Method to edit the product details using service client
        /// </summary>
        static void editProductDetails()
        {
            //Intialise service client
            var client = new NorthwindService.NorthwindServiceClient();

            Console.WriteLine("Enter name of Product from the list to update details: ");
            string name = Console.ReadLine();

            GreenForeground("Product Details: ");
            var productData = client.GetProductData(name);
            if (productData != null)
            {
                Console.WriteLine("Enter new product name: ");
                string newName = Console.ReadLine();
                Console.WriteLine("Enter new quantity per unit: ");
                string newQuantity = Console.ReadLine();

                productData.ProductName = newName;
                productData.QuantityPerUnit = newQuantity;

                client.UpdateProducts(productData);
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product could not found.");
            }
         
            Console.WriteLine();
        }

        /// <summary>
        /// Method to give green colour to output
        /// </summary>
        public static void GreenForeground(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
        }

    }
}
