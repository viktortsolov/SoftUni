CREATE VIEW v_HighestPeak
AS
SELECT TOP(1) *
		FROM [Peaks]
	ORDER BY [Elevation] DESC