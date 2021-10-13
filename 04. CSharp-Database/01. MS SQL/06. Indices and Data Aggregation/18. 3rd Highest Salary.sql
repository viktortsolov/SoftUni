SELECT DISTINCT
	DepartmentID,
	Salary AS [ThirdHighestSalary]
FROM (
		SELECT 
			e.DepartmentID,
			e.Salary,
			DENSE_RANK() OVER(PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS [SalaryRank]
		FROM Employees AS e
	 ) AS [SalaryRankingQuery]
WHERE SalaryRank = 3