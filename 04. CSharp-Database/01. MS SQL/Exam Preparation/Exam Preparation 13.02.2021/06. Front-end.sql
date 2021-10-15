SELECT
	Id,
	Name,
	Size
FROM Files
	WHERE Size >= 1000 AND RIGHT([Name], 4) = 'html'
	ORDER BY Size DESC,
			 Id ASC,
			 Name ASC