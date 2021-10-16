SELECT 
	DistributorName, 
	IngredientName, 
	ProductName, 
	AverageRate
FROM (
		SELECT 
			d.[Name] AS [DistributorName],
			i.[Name] AS [IngredientName],
			p.[Name] AS [ProductName],
			AVG(f.Rate) AS [AverageRate]
		FROM Distributors AS d
		JOIN Ingredients AS i 
			ON d.Id = i.DistributorId
		JOIN ProductsIngredients AS [pi] 
			ON i.Id = pi.IngredientId
		JOIN Products AS p 
			ON [pi].ProductId = p.Id
		JOIN Feedbacks AS f 
			ON p.Id = f.ProductId
		GROUP BY d.[Name], i.[Name], p.[Name]
	  ) AS Result
WHERE AverageRate BETWEEN 5 AND 8
ORDER BY DistributorName, IngredientName, ProductName