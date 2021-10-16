SELECT
	c.Id,
	CONCAT(c.FirstName, ' ', c.LastName) AS ClientName,
	c.Email
FROM Clients c
LEFT JOIN ClientsCigars cc ON c.Id = cc.ClientId
WHERE cc.CigarId IS NULL
ORDER BY ClientName ASC