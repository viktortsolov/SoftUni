SELECT 
	MIN(s.AvgSalary) AS MinAverageSalary
FROM 
	(SELECT AVG(Salary) AS AvgSalary FROM Employees GROUP BY DepartmentID) AS s