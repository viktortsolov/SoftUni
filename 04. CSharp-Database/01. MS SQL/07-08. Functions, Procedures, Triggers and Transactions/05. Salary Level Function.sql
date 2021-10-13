CREATE FUNCTION udf_GetSalaryLevel(@Salary DECIMAL(18, 4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10);

	IF(@salary < 30000)
		SET @result = 'Low'
	ELSE IF(@salary <= 50000)
		SET @result = 'Average'
	ELSE
		SET @result = 'High'

	RETURN @result
END;

SELECT 
	e.Salary, dbo.udf_GetSalaryLevel(e.Salary) AS [Salary Level]
FROM Employees as e