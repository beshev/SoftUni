SELECT r.DepartmentID,r.Salary
FROM (SELECT *,ROW_NUMBER() OVER(PARTITION BY r.DepartmentID ORDER BY r.Salary DESC) as [Rank]
FROM (SELECT e.DepartmentID,e.Salary
	FROM Employees AS e
	GROUP BY e.DepartmentID,e.Salary
 ) AS r) AS r
 WHERE r.[Rank] = 3
