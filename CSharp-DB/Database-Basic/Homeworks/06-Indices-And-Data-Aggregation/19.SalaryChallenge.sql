SELECT TOP(10) FirstName,LastName,e.DepartmentID
FROM (SELECT DepartmentID,AVG(Salary) AS AvgSalary
	FROM Employees
 GROUP BY DepartmentID) AS r,Employees AS e
 WHERE r.DepartmentID = e.DepartmentID AND e.Salary > r.AvgSalary