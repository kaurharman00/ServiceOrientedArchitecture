using ProductService.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ProductService.Service
{
    public class NorthwindService : INorthwindService
    {
        /// <summary>
        /// Method to get all products details 
        /// </summary>
        public ProductData GetProductData(string pName)
        {
            Console.WriteLine("Client called GetProductData!");

            ProductData productData = new ProductData();

            try
            {
                using(var data = new NorthwindEntities())
                {
                    Product product = data.Products.First((p) => p.ProductName == pName);

                    productData.ProductName = product.ProductName;
                    productData.QuantityPerUnit = product.QuantityPerUnit;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return productData;
        }

        /// <summary>
        /// Method to get all products names list
        /// </summary>
        public List<string> GetProducts()
        {
            Console.WriteLine("Client called GetProducts!");

            var pList = new List<string>();

            try
            {
                using (var data = new NorthwindEntities())
                {
                    var productsName = (from p in data.Products orderby p.ProductName select p.ProductName).Take(5);

                    pList = productsName.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return pList;
        }

        /// <summary>
        /// Method to update products details
        /// </summary>
        public void UpdateProducts(ProductData pData)
        {
            Console.WriteLine("Client called UpdateProducts!");

            try
            {
                using (var data = new NorthwindEntities())
                {
                    var product = data.Products.FirstOrDefault((p) => p.ProductName == pData.ProductName);
                    if (product != null)
                    {
                        product.ProductName = pData.ProductName;
                        product.QuantityPerUnit = pData.QuantityPerUnit;
                        data.SaveChanges();
                        Console.WriteLine("Product updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
    }
}
