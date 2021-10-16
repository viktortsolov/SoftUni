SELECT
	c.FirstName,
	c.Age,
	c.PhoneNumber
FROM Customers c
JOIN Countries com
ON c.CountryId = com.Id
WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') OR (RIGHT(c.PhoneNumber, 2) = '38' AND com.Name != 'Greece')
ORDER BY c.FirstName ASC, c.Age DESC