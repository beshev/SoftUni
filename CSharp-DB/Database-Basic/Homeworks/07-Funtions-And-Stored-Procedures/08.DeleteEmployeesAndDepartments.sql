CREATE PROC usp_DeleteEmployeesFromDepartment @departmenId INT
AS
BEGIN
	DELETE FROM EmployeesProjects
		WHERE EmployeeID IN(SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmenId)

	UPDATE Employees
		SET ManagerID = NULL
		WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmenId)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
		SET ManagerID = NULL
		WHERE DepartmentID = @departmenId

	DELETE FROM Employees
		WHERE DepartmentID = @departmenId

	DELETE FROM Departments
		WHERE DepartmentID = @departmenId


	SELECT COUNT(*) FROM Employees
		WHERE DepartmentID = @departmenId

END