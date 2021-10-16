SELECT u.Username,c.[Name]
	FROM Reports AS r
	JOIN Users AS u ON r.UserId = u.Id
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE DAY(u.Birthdate) = DAY(r.OpenDate)
	ORDER BY u.Username,c.[Name]