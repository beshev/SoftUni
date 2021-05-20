CREATE OR ALTER TRIGGER tr_LogDeletedEmployees
ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees
	SELECT FirstName,LastName,MiddleName,JobTitle,DepartmentID,Salary FROM deleted
END