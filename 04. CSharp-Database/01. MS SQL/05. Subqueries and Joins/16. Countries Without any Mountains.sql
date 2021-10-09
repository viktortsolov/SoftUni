SELECT 
	COUNT([Count]) AS [Count] 
FROM (
		SELECT
			COUNT(c.CountryCode) AS [Count]
		FROM Countries c
		LEFT JOIN MountainsCountries mc
		ON c.CountryCode = mc.CountryCode
		WHERE mc.MountainId IS NULL
		GROUP BY c.CountryCode) AS CountSubQuery
GROUP BY [Count] 