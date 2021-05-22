DECLARE @UserGameId INT = 
(
	SELECT Id
		FROM UsersGames
		WHERE UserId = (SELECT Id FROM Users WHERE Username = 'Stamat')
			  AND GameId = (SELECT Id FROM Games WHERE [Name] = 'Safflower')
)

DECLARE @StamatCash DECIMAL(18,2) = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)
DECLARE @ItemsPrice DECIMAL(18,2) = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)

IF(@StamatCash >= @ItemsPrice)
BEGIN 
	BEGIN TRANSACTION
		INSERT INTO UserGameItems
		SELECT Id,@UserGameId FROM Items  WHERE MinLevel BETWEEN 11 AND 12

		UPDATE UsersGames
			SET Cash = Cash - @ItemsPrice
			WHERE Id = @UserGameId
	COMMIT
END

SET @StamatCash  = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)
SET @ItemsPrice  = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF(@StamatCash >= @ItemsPrice)
BEGIN 
	BEGIN TRANSACTION
		INSERT INTO UserGameItems
		SELECT Id,@UserGameId FROM Items  WHERE MinLevel BETWEEN 19 AND 21

		UPDATE UsersGames
			SET Cash = Cash - @ItemsPrice
			WHERE Id = @UserGameId
	COMMIT
END

SELECT it.[Name] AS [Item Name]
	FROM UsersGames AS ug
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS it ON it.Id = ugi.ItemId
	WHERE ug.Id = @UserGameId
 ORDER BY [Item Name]