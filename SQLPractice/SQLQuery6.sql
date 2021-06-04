--Task1

SELECT [ProductID], [Name], [ProductNumber], [Color]
  FROM [SalesLT].[Product];

SELECT [CustomerID], [FirstName], [LastName], [EmailAddress], [Phone]
 FROM [SalesLT].[Customer];

--Task2

SELECT [ProductID], [Name], [ProductNumber], [Color]
  FROM [SalesLT].[Product]
  WHERE [Color] = 'Black';

SELECT [ProductID], [Name], [ProductNumber], [Color]
  FROM [SalesLT].[Product]
  WHERE [Color] = 'Black' OR [Color] = 'Grey' OR [Color] = 'Multi';

SELECT [ProductID], [Name], [ProductNumber], [Color]
  FROM [SalesLT].[Product]
  WHERE [Color] = 'Black' OR [Color] = 'Yellow';

SELECT [ProductID], [Name], [ProductNumber], [Weight]
  FROM [SalesLT].[Product]
  WHERE [Weight] is NULL;

SELECT [ProductID], [Name], [ProductNumber], [Weight]
  FROM [SalesLT].[Product]
  WHERE [Weight] > 1000;

SELECT [ProductID], [Name], [ProductNumber], [Weight]
  FROM [SalesLT].[Product]
  WHERE [Weight] < 6000;

SELECT [ProductID], [Name], [ProductNumber], [Weight]
  FROM [SalesLT].[Product]
  WHERE [Weight] BETWEEN 2000 AND 5000;
  
SELECT [ProductID], [Name], [ProductNumber]
  FROM [SalesLT].[Product]
  WHERE [ProductNumber] LIKE 'BB%' OR [ProductNumber] LIKE 'BK%';

SELECT [ProductID], [Name], [ProductNumber], [SellEndDate]
  FROM [SalesLT].[Product]
  WHERE [SellEndDate] > GETDATE();

  --Task3

SELECT [ProductID], [Name], [ProductNumber], [Color]
  FROM [SalesLT].[Product]
  WHERE [Color] IS NOT NULL
  ORDER BY [Color];

SELECT [ProductID], [Name], [ProductNumber], [Color], [Weight]
  FROM [SalesLT].[Product]
  WHERE [Color] IS NOT NULL AND [Weight] IS NOT NULL
  ORDER BY [Color] ASC, [Weight] DESC;

SELECT [ProductID], [Name], [ProductNumber], [Weight]
  FROM [SalesLT].[Product]
  WHERE [Weight] IS NOT NULL
  ORDER BY [ProductNumber] ASC, [Weight] DESC;

  --Task4

SELECT TOP(10) [ProductID], [Name], [ProductNumber]
  FROM [SalesLT].[Product];

SELECT TOP(10) [ProductID], [Name], [ProductNumber], [Weight]
  FROM [SalesLT].[Product]
  ORDER BY [Weight] DESC;

SELECT TOP(10) [ProductID], [Name], [ProductNumber], [Weight]
  FROM [SalesLT].[Product]
  WHERE [Weight] IS NOT NULL
  ORDER BY [Weight] ASC;

  WITH first_10_skip
  AS 
  (
	SELECT ROW_NUMBER() OVER (ORDER BY [Weight] DESC) AS item,
	[ProductID], [Name], [ProductNumber], [Weight]	
	FROM [SalesLT].[Product]
  )
  SELECT * 
  FROM first_10_skip 
  WHERE item BETWEEN 10 AND 20;

  --Task5 

  SELECT a.[ProductID], a.[Name], a.[ProductNumber], a.[Color], a.[Weight],
  b.[UnitPrice], CONCAT(b.[UnitPriceDiscount] * 100, + '%') AS Discount
  FROM [SalesLT].[Product] a
  JOIN [SalesLT].[SalesOrderDetail] b
  ON a.[ProductID] = b.[ProductID]

  SELECT a.[CustomerID], a.[FirstName], a.[LastName], a.[EmailAddress], a.[Phone],
  c.[City], c.[CountryRegion], c.[PostalCode], c.[AddressLine1], c.[AddressLine2]
  FROM [SalesLT].[Customer] a
  JOIN [SalesLT].[CustomerAddress] b
  ON a.CustomerID = b.CustomerID
  JOIN [SalesLT].[Address] c
  ON b.[AddressID] = c.[AddressID]

  SELECT a.[ProductID], a.[Name], a.[ProductNumber],
  b.[Name] AS 'CategoryParent', c.[Name] AS 'CategoryChild'
  FROM [SalesLT].[Product] a
  JOIN [SalesLT].[ProductCategory] b
  ON a.[ProductCategoryID] = b.[ProductCategoryID]
  LEFT JOIN [SalesLT].[ProductCategory] c
  ON c.[ProductCategoryID] = b.[ParentProductCategoryID]

  --Task6

  SELECT COUNT(*) FROM [SalesLT].[Product];
  
  SELECT COUNT(*) FROM [SalesLT].[Product]
  WHERE [SellEndDate] < GETDATE();

  SELECT COUNT(*) FROM [SalesLT].[Product]
  WHERE [Weight] IS NULL;

  SELECT AVG([Weight]) FROM [SalesLT].[Product]
  WHERE [Weight] IS NOT NULL;

  SELECT AVG(ISNULL([Weight], 0)) FROM [SalesLT].[Product]

  SELECT MIN([Weight]), MAX([Weight]) 
  FROM [SalesLT].[Product]
  
  SELECT b.[ProductCategoryID], b.[Name], COUNT(a.[ProductID]) AS 'Count',
   SUM(a.[Weight]) AS 'Weight', MIN(a.[Weight]) AS 'Min',
    MAX(a.[Weight]) AS 'Max', AVG(ISNULL(a.[Weight], 0)) AS 'Average'
  FROM [SalesLT].[Product] a
  JOIN [SalesLT].[ProductCategory] b
  ON a.[ProductCategoryID] = b.[ProductCategoryID]
  GROUP BY b.[Name], b.[ProductCategoryID]

    SELECT b.[ProductCategoryID], b.[Name],
   SUM(ISNULL(a.[Weight], 0)) AS 'Weight'
  FROM [SalesLT].[Product] a
  JOIN [SalesLT].[ProductCategory] b
  ON a.[ProductCategoryID] = b.[ProductCategoryID]
  GROUP BY b.[Name], b.[ProductCategoryID]

    SELECT b.[ProductCategoryID], b.[Name], COUNT(a.[ProductID]) AS 'Count',
   SUM(a.[Weight]) AS 'Weight', MIN(a.[Weight]) AS 'Min',
    MAX(a.[Weight]) AS 'Max', AVG(ISNULL(a.[Weight], 0)) AS 'Average'
  FROM [SalesLT].[Product] a
  JOIN [SalesLT].[ProductCategory] b
  ON a.[ProductCategoryID] = b.[ProductCategoryID]
  GROUP BY b.[Name], b.[ProductCategoryID]
  HAVING COUNT(a.[ProductID]) IS NOT NULL AND SUM(a.[Weight]) IS NOT NULL
  AND MIN(a.[Weight]) IS NOT NULL AND MAX(a.[Weight]) IS NOT NULL
  AND AVG(ISNULL(a.[Weight], 0)) IS NOT NULL

   SELECT b.[ProductCategoryID], b.[Name], COUNT(a.[ProductID]) AS 'Count',
   SUM(a.[Weight]) AS 'Weight', MIN(a.[Weight]) AS 'Min',
    MAX(a.[Weight]) AS 'Max', AVG(ISNULL(a.[Weight], 0)) AS 'Average'
  FROM [SalesLT].[Product] a
  JOIN [SalesLT].[ProductCategory] b
  ON a.[ProductCategoryID] = b.[ProductCategoryID]
  GROUP BY b.[Name], b.[ProductCategoryID]
  HAVING COUNT(a.[ProductID]) IS NOT NULL AND SUM(a.[Weight]) IS NOT NULL
  AND MIN(a.[Weight]) IS NOT NULL AND MAX(a.[Weight]) IS NOT NULL
  AND AVG(ISNULL(a.[Weight], 0)) IS NOT NULL
  AND SUM(a.[Weight]) > 10000;

  --Task7

  SELECT a.[ProductCategoryID], a.[Name],
  SUM(c.UnitPrice) AS 'TotalSum'
  FROM [SalesLT].[ProductCategory] a
  LEFT JOIN [SalesLT].[Product] b
  ON a.[ProductCategoryID] = b.[ProductCategoryID]
  JOIN [SalesLT].[SalesOrderDetail] c
  ON c.ProductID = b.ProductID
  GROUP BY a.[ProductCategoryID], a.[Name];