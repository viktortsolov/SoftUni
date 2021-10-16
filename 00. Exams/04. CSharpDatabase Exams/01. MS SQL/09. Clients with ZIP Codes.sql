SELECT
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	a.Country,
	a.ZIP,
	CONCAT('$', MAX(cig.PriceForSingleCigar)) AS CigarPrice
FROM Clients c
JOIN Addresses a ON c.AddressId = a.Id
JOIN ClientsCigars cc ON c.Id = cc.ClientId
JOIN Cigars cig ON cig.Id = cc.CigarId
WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP
ORDER BY FullName ASC