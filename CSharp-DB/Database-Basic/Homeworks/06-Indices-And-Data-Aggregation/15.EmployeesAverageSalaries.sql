SELECT * INTO EmployeesOver30000Salary
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesOver30000Salary
	WHERE ManagerID = 42

UPDATE EmployeesOver30000Salary SET Salary += 5000 WHERE DepartmentID = 1

SELECT e.DepartmentID,AVG(e.Salary) AS AverageSalary
	FROM EmployeesOver30000Salary AS e
 GROUP BY e.DepartmentID
