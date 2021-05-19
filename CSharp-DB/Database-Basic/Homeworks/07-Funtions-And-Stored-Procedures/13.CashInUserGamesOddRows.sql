CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(MAX))
RETURNS @Table TABLE(SumCash DECIMAL(18,4))
AS
BEGIN
	 DECLARE @Result DECIMAL(18,2) = (SELECT SUM(r.Cash)
		FROM (SELECT Cash, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS [Rows]
				FROM UsersGames
				WHERE GameId IN (SELECT Id FROM Games WHERE [Name] = @GameName)) AS r
		WHERE r.[Rows] % 2 != 0)

	INSERT INTO @Table VALUES (@Result)
	RETURN
END