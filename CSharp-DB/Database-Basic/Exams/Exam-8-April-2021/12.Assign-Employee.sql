CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @RepoDepId INT = (
								SELECT c.DepartmentId  
								FROM Reports AS r
								JOIN Categories AS c ON c.Id = r.CategoryId
								WHERE r.Id = @ReportId
						   )
	DECLARE @EmployeeDepId INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)

	IF @RepoDepId != @EmployeeDepId
		RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)

	UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
END

EXEC usp_AssignEmployeeToReport 17,2
SELECT Id, CategoryId, EmployeeId
  FROM Reports
 WHERE Id = 2