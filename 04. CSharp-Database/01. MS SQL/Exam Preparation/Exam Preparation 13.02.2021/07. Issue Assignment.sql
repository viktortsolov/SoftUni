SELECT
	i.Id,
	CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues i
JOIN Users u
ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, i.AssigneeId ASC