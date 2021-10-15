SELECT p.Id,p.[Name],CONCAT(p.Size,'KB')
	FROM Files AS P
	LEFT JOIN Files AS c ON p.Id = c.ParentId
	WHERE c.Id IS NULL
	ORDER BY c.Id,c.[Name],c.Size DESC