CREATE PROC usp_AssignProject @emloyeeId INT , @projectID INT
AS
BEGIN TRANSACTION

 	DECLARE @EmployeeProjectsCount INT = (SELECT COUNT(*)
												FROM  EmployeesProjects
											WHERE EmployeeID = @emloyeeId)
	IF (@EmployeeProjectsCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!',16,1)
	END
	INSERT INTO EmployeesProjects(EmployeeID,ProjectID) VALUES
	(@emloyeeId,@projectID)
COMMIT