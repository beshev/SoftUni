SELECT u.Username,g.[Name] AS Game,COUNT(it.Name) AS [Item Count],SUM(it.Price) AS [Items Price]
	FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS it ON it.Id = ugi.ItemId
GROUP BY u.Username,g.[Name]
HAVING COUNT(it.Name) >= 10
ORDER BY [Item Count] DESC, [Items Price] DESC