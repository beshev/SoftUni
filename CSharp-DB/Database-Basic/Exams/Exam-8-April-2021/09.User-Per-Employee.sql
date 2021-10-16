SELECT CONCAT(em.FirstName,' ',em.LastName) AS FullName,COUNT(r.UserId) AS UsersCount
	FROM Reports AS r
	RIGHT JOIN Employees AS em ON em.Id = r.EmployeeId
	LEFT JOIN Users AS u ON u.Id = r.UserId
	GROUP BY em.FirstName,em.LastName
	ORDER BY UsersCount DESC,FullName