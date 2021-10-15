SELECT
	u.Username,
	AVG(f.Size) AS Size
FROM Files f
JOIN Commits c
ON f.CommitId = c.Id
JOIN Users u
ON c.ContributorId = u.Id
GROUP BY u.Username
ORDER BY Size DESC, u.Username ASC