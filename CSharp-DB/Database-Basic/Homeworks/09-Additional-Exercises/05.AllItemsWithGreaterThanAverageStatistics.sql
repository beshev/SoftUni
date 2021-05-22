DECLARE @AvgLuck FLOAT = (SELECT AVG(Luck) FROM [Statistics])
DECLARE @AvgSpeed FLOAT = (SELECT AVG(Speed) FROM [Statistics])
DECLARE @AvgMind FLOAT = (SELECT AVG(Mind) FROM [Statistics])

SELECT i.[Name],i.Price,i.MinLevel,s.Strength,s.Defence,s.Speed,s.Luck,s.Mind
	FROM Items AS i
	JOIN [Statistics] AS s ON s.Id = i.StatisticId
	WHERE  s.Luck > @AvgLuck
		  AND s.Speed > @AvgSpeed
		  AND s.Mind > @AvgMind
ORDER BY i.Name