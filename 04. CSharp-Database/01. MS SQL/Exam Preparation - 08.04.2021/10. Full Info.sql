SELECT 
		CASE 
			WHEN CONCAT(e.FirstName, ' ', e.LastName) = ' ' 
			THEN 'None' 
			ELSE CONCAT(e.FirstName, ' ', e.LastName) 
		END AS Employee,
		CASE 
			WHEN d.Name = '' OR d.Name IS NULL 
			THEN 'None' 
			ELSE d.Name 
		END AS Department,
		c.Name AS CategoryName,
		r.Description,
		FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
		s.Label AS Status,
		CASE
			WHEN u.Name = '' 
			THEN 'None' 
			ELSE u.Name 
		END AS [User]
	FROM Reports r
	LEFT JOIN Employees e 
		ON r.EmployeeId = e.Id
	LEFT JOIN Departments d 
		ON e.DepartmentId = d.Id
	LEFT JOIN Categories c 
		ON r.CategoryId = c.Id
	LEFT JOIN Status s 
		ON r.StatusId = s.Id
	LEFT JOIN Users u 
		ON r.UserId = u.Id
  ORDER BY e.FirstName DESC,
		   e.LastName DESC, 
		   d.[Name], 
		   c.[Name],
		   r.[Description], 
		   r.OpenDate, 
		   [Status], 
		   [User]