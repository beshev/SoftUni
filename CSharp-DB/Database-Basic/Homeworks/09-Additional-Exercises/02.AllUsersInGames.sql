SELECT g.[Name] AS Game,gp.[Name] AS [Game Type],u.Username,ug.[Level],ug.Cash,cr.[Name] AS [Character]
	FROM UsersGames AS ug
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN GameTypes AS gp ON gp.Id = g.GameTypeId
	JOIN Users AS u ON u.Id = ug.UserId
	JOIN Characters AS cr ON cr.Id = ug.CharacterId
ORDER BY ug.[Level] DESC,u.Username,g.[Name]