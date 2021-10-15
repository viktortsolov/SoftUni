SELECT TOP (5)
	c.[Name] AS CategoryName, 
	COUNT(r.CategoryId) AS ReortsNumber
FROM Reports AS r
JOIN Categories AS c
ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY COUNT(r.CategoryId) DESC, c.[Name] ASC