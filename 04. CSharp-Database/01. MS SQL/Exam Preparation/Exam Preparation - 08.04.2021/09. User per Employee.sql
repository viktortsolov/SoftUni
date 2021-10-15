SELECT
	CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	COUNT(u.Id) AS [UsersCount]
  FROM Employees e
  LEFT JOIN Reports r
  ON e.Id = r.EmployeeId
  LEFT JOIN Users u
  ON u.Id = r.UserId
  GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
  ORDER BY COUNT(u.Id) DESC, FullName ASC