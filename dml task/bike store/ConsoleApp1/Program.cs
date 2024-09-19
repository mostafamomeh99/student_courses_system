using ConsoleApp1.Data;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ApplicationDbContext data=new ApplicationDbContext();

            //Retrieve all categories from the production.categories table.

            var categries = data.Categories.ToList();

            foreach (var category in categries)
            {
                Console.WriteLine($"categoryid:{category.CategoryId},categoryname:{category.CategoryName}");
            }

            //Retrieve the first product from the production.products table.

            var products1 = data.Products.FirstOrDefault();

            Console.WriteLine(products1.ProductName);

            //Retrieve a specific product from the production.products table by ID.

            var products2 = data.Products.Where(e => e.ProductId == 2);
            foreach (var item in products2)
            { Console.WriteLine($"ProductId:{item.ProductId},ProductName:{item.ProductName}"); }


            //Retrieve all products from the production.products table with a certain model year.

            var products3 = data.Products.Where(e => e.ModelYear == 2016);
            foreach (var item in products3)
            { Console.WriteLine($"ProductId:{item.ProductId},ProductName:{item.ProductName}"); }

            //Retrieve a specific customer from the sales.customers table by ID.
            var customer1 = data.Customers.Where(e => e.CustomerId == 2);
            foreach (var item in customer1)
            { Console.WriteLine($"CustomerId:{item.CustomerId},CustomerName:{item.FirstName}"); }

            //Retrieve a list of product names and their corresponding brand names.
            var products4 = data.Products.Include(e => e.Brand);
            foreach (var item in products4)
            { Console.WriteLine($"ProductName:{item.ProductName},BrandName:{item.Brand.BrandName}"); }

            //Count the number of products in a specific category.
            var products5 = data.Products.Count(e => e.ModelYear == 2016);
            Console.WriteLine(products5);

            //Calculate the total list price of all products in a specific category.
            var products6 = data.Products.Include(e => e.Category).Where(e => e.Category.CategoryId == 1);
            foreach (var item in products6)
            { Console.WriteLine($"ProductId:{item.ProductId},ProductName:{item.ProductName},CategoryID={item.Category.CategoryId}"); }

            //Calculate the average list price of products.
            var products7 = data.Products.Average(e => e.ListPrice);
            Console.WriteLine(products7);

            //Retrieve orders that are completed.
            var orders1 = data.Orders.Where(e => e.OrderStatus == 4);
            Console.WriteLine("completed orders");
            foreach (var item in orders1)
            { Console.WriteLine($"OrderId:{item.OrderId},OrderStatus:{item.OrderStatus}"); }



        }


    }
}
