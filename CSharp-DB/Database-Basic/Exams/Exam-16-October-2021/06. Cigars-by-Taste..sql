SELECT c.Id,c.CigarName,c.PriceForSingleCigar,t.TasteType,t.TasteStrength
	FROM Cigars AS c
	JOIN Tastes AS t on t.Id = c.TastId
	WHERE t.TasteType IN ('Earthy','Woody')
	ORDER BY c.PriceForSingleCigar DESC