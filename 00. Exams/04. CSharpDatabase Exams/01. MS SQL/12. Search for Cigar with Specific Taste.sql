CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT
		c.CigarName,
		CONCAT('$', c.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.[Length], ' cm') AS CigarLength,
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM Cigars c
		JOIN Tastes t ON c.TastId = t.Id
		JOIN Sizes s ON c.SizeId = s.Id
		JOIN Brands b on c.BrandId = b.Id
	WHERE t.TasteType = @taste
	ORDER BY s.[Length] ASC, s.RingRange DESC
END