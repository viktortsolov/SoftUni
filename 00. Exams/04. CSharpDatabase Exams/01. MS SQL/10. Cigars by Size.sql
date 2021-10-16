SELECT
	c.LastName,
	AVG(s.Length) AS CigarLength,
	CEILING(AVG(s.RingRange)) AS CigarRingRange
FROM Clients c
JOIN ClientsCigars cc ON c.Id = cc.ClientId
JOIN Cigars cig ON cc.CigarId = cig.Id
JOIN Sizes s ON s.Id = cig.SizeId
GROUP BY c.LastName
ORDER BY CigarLength DESC