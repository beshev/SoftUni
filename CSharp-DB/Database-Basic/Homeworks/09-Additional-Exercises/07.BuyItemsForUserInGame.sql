DECLARE @AlexId INT = (SELECT Id FROM Users WHERE Username = 'Alex')
DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = 'Edinburgh')

DECLARE @AlexGameId INT  = 
(
	SELECT Id
		FROM UsersGames
		WHERE UserId = @AlexId AND 
			  GameId = @GameId
)

DECLARE @TotalPriceOfItems DECIMAL(15,2) =
(
	SELECT SUM(It.Price) AS [Total Price]
		FROM Items AS it
		WHERE it.[Name] IN ('Blackguard','Bottomless Potion of Amplification','Eye of Etlich (Diablo III)','Gem of Efficacious Toxin','Golden Gorget of Leoric','Hellfire Amulet')
)

INSERT INTO UserGameItems(ItemId,UserGameId)
SELECT it.Id,@AlexGameId FROM Items AS it
		WHERE it.[Name] IN ('Blackguard','Bottomless Potion of Amplification','Eye of Etlich (Diablo III)','Gem of Efficacious Toxin','Golden Gorget of Leoric','Hellfire Amulet')

UPDATE UsersGames
	SET CAsh -= @TotalPriceOfItems
	WHERE id = @AlexGameId

SELECT us.Username,g.[Name],ug.Cash,it.[Name] AS [Item Name]	
	FROM UsersGames AS ug
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS it ON it.Id = ugi.ItemId
	JOIN Users AS us ON us.Id = ug.UserId
WHERE ug.GameId = @GameId
ORDER BY it.[Name]

