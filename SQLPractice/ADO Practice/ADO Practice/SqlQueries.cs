using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADO_Practice
{
    public class SqlQueries
    {
        public List<ProductCategoryInfo> GetProductCategoryInfo(string connectionString)
        {
            List<ProductCategoryInfo> list = new List<ProductCategoryInfo>();

            string stringExpression = @"SELECT a.[ProductCategoryID], a.[Name],
            SUM(ISNULL(b.[ListPrice], 0)) AS 'Total Sum'
            FROM [SalesLT].[ProductCategory] a
            RIGHT JOIN [SalesLT].[Product] b
            ON b.[ProductCategoryID] = a.[ProductCategoryID]
            LEFT JOIN [SalesLT].[SalesOrderDetail] c
            ON b.[ProductID] = c.[ProductID]
            WHERE b.[SellEndDate] < @condition
            GROUP BY a.[ProductCategoryID], a.[Name]";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = stringExpression;
                    sqlCommand.Parameters.AddWithValue("@condition", DateTime.Today);

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return list;
                        }

                        while (reader.Read())
                        {
                            var categoryID = (int)reader.GetValue(0);
                            var categoryName = (string)reader.GetValue(1);
                            var categoryTotalPrice = (decimal)reader.GetValue(2);

                            var row = new ProductCategoryInfo
                            {
                                ProductCategoryID = categoryID,
                                Name = categoryName,
                                TotalSum = categoryTotalPrice
                            };

                            list.Add(row);
                        }

                        return list;
                    }
                }
            }
        }

        public List<CustomerInfo> GetCustomersWithDiscountHigherThan40(string connectionString)
        {
            List<CustomerInfo> list = new List<CustomerInfo>();

            string stringExpression = @"SELECT a.[CustomerID], a.[FirstName], c.[UnitPriceDiscount] as 'Discount'
            FROM [SalesLT].[Customer] a
            JOIN [SalesLT].[SalesOrderHeader] b
            ON a.CustomerID = b.CustomerID
            JOIN [SalesLT].[SalesOrderDetail] c
            ON b.SalesOrderID = c.SalesOrderID
            GROUP BY a.[CustomerID], a.[FirstName], c.[UnitPriceDiscount]
            HAVING MAX(c.[UnitPriceDiscount]) >= @condition";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = stringExpression;
                    sqlCommand.Parameters.AddWithValue("@condition", "0.4");

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return list;
                        }

                        while (reader.Read())
                        {
                            var customerID = (int)reader.GetValue(0);
                            var customerName = (string)reader.GetValue(1);
                            var customerDiscount = (decimal)reader.GetValue(2);

                            var row = new CustomerInfo
                            {
                                CustomerID = customerID,
                                FirstName = customerName,
                                Discount = customerDiscount
                            };

                            list.Add(row);
                        }

                        return list;
                    }
                }
            }
        }

        public List<CustomerInfo> GetCustomersWithTotalPurchasesHigherThan15000(string connectionString)
        {
            List<CustomerInfo> list = new List<CustomerInfo>();

            string stringExpression = @"SELECT a.[CustomerID], a.[FirstName], a.[LastName]
            FROM [SalesLT].[Customer] a
            JOIN [SalesLT].[SalesOrderHeader] b
            ON a.CustomerID = b.CustomerID
            JOIN [SalesLT].[SalesOrderDetail] c
            ON b.SalesOrderID = c.SalesOrderID
            GROUP BY a.[CustomerID], a.[FirstName], a.[LastName]
            HAVING SUM(c.[UnitPrice]) > @condition";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = stringExpression;
                    sqlCommand.Parameters.AddWithValue("@condition", "15000");

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return list;
                        }

                        while (reader.Read())
                        {
                            var customerID = (int)reader.GetValue(0);
                            var customerFirstName = (string)reader.GetValue(1);
                            var customerSecondName = (string)reader.GetValue(2);

                            var row = new CustomerInfo
                            {
                                CustomerID = customerID,
                                FirstName = customerFirstName,
                                SecondName = customerSecondName
                            };

                            list.Add(row);
                        }

                        return list;
                    }
                }
            }
        }
    }
}
