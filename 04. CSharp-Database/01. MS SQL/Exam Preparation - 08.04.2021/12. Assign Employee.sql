CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @EmployeeDepartmentId INT;
	SET @EmployeeDepartmentId = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)

	DECLARE @CategoryDepartmentId INT;
	SET @CategoryDepartmentId = (SELECT c.DepartmentId FROM Reports r 
									   LEFT JOIN Categories c ON r.CategoryId = c.Id	
									WHERE r.Id = @ReportId)

	IF @EmployeeDepartmentId != @CategoryDepartmentId
	BEGIN
		RAISERROR ('Employee doesn''t belong to the appropriate department!',16, 1)
	END

	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
END