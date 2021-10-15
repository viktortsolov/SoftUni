SELECT 
		f.Id,
		f. [Name],
		CAST(f.Size AS VARCHAR(30)) + 'KB' AS Size
	FROM Files AS f
	LEFT JOIN Files AS p 
	ON f.Id = p.ParentId
	WHERE p.ParentId IS NULL
	ORDER BY f.Id, f.[Name], f.Size DESC