SELECT
	c.CountryCode,
	COUNT(c.CountryCode) AS MountainRanges
FROM Countries c
LEFT JOIN MountainsCountries mc
ON c.CountryCode = mc.CountryCode
WHERE c.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode