SELECT c.LastName,AVG(s.[Length]) AS CiagrLength,CEILING(AVG(s.RingRange)) AS CiagrRingRange
	FROM Clients AS c
	JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
	JOIN Cigars as cg ON cg.Id = cc.CigarId
	JOIN Sizes AS s ON s.Id = cg.SizeId
	GROUP BY c.LastName
	ORDER BY CiagrLength DESC