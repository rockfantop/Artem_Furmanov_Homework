    using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-Q1TS6GH\\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var queries = new SqlQueries();
            var list = queries.GetProductCategoryInfo(connectionString);

            foreach (var item in list)
            {
                Console.WriteLine($"ID: {item.ProductCategoryID} Name: {item.Name} TotalSum: {item.TotalSum}");
            }

            Console.WriteLine("\n------------------------\n");

            var list2 = queries.GetCustomersWithDiscountHigherThan40(connectionString);

            foreach (var item in list2)
            {
                Console.WriteLine($"ID: {item.CustomerID} Name: {item.FirstName} TotalSum: {item.Discount}");
            }

            Console.WriteLine("\n------------------------\n");

            var list3 = queries.GetCustomersWithTotalPurchasesHigherThan15000(connectionString);

            foreach (var item in list3)
            {
                Console.WriteLine($"ID: {item.CustomerID} Name: {item.FirstName} SecondName: {item.SecondName}");
            }
        }
    }
}
