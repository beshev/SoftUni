CREATE PROC usp_CalculateFutureValueForAccount @Id INT,@Interest FLOAT
AS 
BEGIN
	SELECT a.Id,
		   ac.FirstName,
		   ac.LastName,
		   a.Balance,
		   dbo.ufn_CalculateFutureValue(a.Balance,@Interest,5) AS [Balance in 5 years]
		FROM AccountHolders AS ac
		JOIN Accounts AS a ON a.AccountHolderId = ac.Id
	 WHERE a.Id = @Id
END