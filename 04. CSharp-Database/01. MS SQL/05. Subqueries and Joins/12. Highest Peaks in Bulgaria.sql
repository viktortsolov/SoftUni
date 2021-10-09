SELECT
	mc.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Peaks p
JOIN Mountains m
ON p.MountainId = m.Id
JOIN MountainsCountries mc
ON mc.MountainId = m.Id
WHERE p.Elevation > 2835 AND mc.CountryCode = 'BG'
ORDER BY p.Elevation DESC