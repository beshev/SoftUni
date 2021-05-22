SELECT U.Username,g.[Name] AS Game,MAX(chr.Name) AS [Character],
	   (SUM(itemStats.Strength) + MAX(gameStats.Strength) + MAX(charStats.Strength)) AS Strength,
	   (SUM(itemStats.Defence) + MAX(gameStats.Defence) + MAX(charStats.Defence)) AS Defence,
	   (SUM(itemStats.Speed) + MAX(gameStats.Speed) + MAX(charStats.Speed)) AS Speed,
	   (SUM(itemStats.Mind) + MAX(gameStats.Mind) + MAX(charStats.Mind)) AS Mind,
	   (SUM(itemStats.Luck) + MAX(gameStats.Luck) + MAX(charStats.Luck)) AS Luck
	FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id
	JOIN Characters AS chr ON chr.Id = ug.CharacterId
	JOIN [Statistics] AS charStats ON charStats.Id = chr.StatisticId
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
	JOIN [Statistics] AS gameStats ON gameStats.Id = gt.BonusStatsId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS it ON it.Id = ugi.ItemId
	JOIN [Statistics] AS itemStats ON itemStats.Id = it.StatisticId
GROUP BY u.Username,g.[Name]
ORDER BY Strength DESC,Defence DESC, Speed DESC, Mind DESC, Luck DESC
 
