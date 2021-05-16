SELECT TOP (1)
	   (SELECT AVG(e.Salary) FROM Employees e WHERE e.DepartmentID = d.DepartmentID) AS MinAverageSalary
	FROM Departments AS d
 ORDER BY MinAverageSalary


SELECT TOP(1) COUNT(Salary) AS MinAverageSalary
	FROM Employees
	GROUP BY DepartmentID
 ORDER BY AVG(Salary)