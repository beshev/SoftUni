SELECT i.[Name] AS Item,i.Price,i.MinLevel,gt.[Name] AS [Forbidden Game Type]
	FROM Items AS i
	LEFT JOIN GameTypeForbiddenItems AS gtf ON gtf.ItemId = i.Id
	LEFT JOIN GameTypes AS gt ON gt.Id = gtf.GameTypeId
ORDER BY gt.[Name] DESC,i.[Name]