SELECT
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DepartmentName
FROM Employees e
JOIN Departments d 
ON e.DepartmentID = d.DepartmentID
WHERE (YEAR(e.HireDate) > '1998') AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
ORDER BY e.HireDate