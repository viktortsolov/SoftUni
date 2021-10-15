SELECT TOP (5)
	r.Id,
	r.Name,
	COUNT(rc.RepositoryId) AS Commits
FROM Commits c
JOIN Repositories r
ON c.RepositoryId = r.Id
JOIN RepositoriesContributors rc
ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id, r.Name