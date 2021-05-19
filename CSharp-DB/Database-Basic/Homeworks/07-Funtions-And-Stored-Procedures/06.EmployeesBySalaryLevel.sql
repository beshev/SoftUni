CREATE PROC usp_EmployeesBySalaryLevel @SalaryLevel VARCHAR(10)
AS
BEGIN 
	SELECT r.FirstName,r.LastName
		FROM (SELECT FirstName,LastName,dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
			FROM Employees) AS r
		WHERE r.[Salary Level] = @SalaryLevel
END