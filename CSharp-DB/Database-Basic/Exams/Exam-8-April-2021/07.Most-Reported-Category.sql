SELECT TOP(5) c.[Name],COUNT(r.Id) AS ReportsNumber
	FROM Categories AS c
	LEFT JOIN Reports AS r ON r.CategoryId = c.Id
	GROUP BY c.[Name]
	ORDER BY ReportsNumber DESC,c.[Name]