CREATE PROC usp_GetHoldersWithBalanceHigherThan @Number DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName,LastName
		FROM AccountHolders a
		JOIN (SELECT AccountHolderId,SUM(Balance) AS totalBalance
				FROM Accounts
			  GROUP BY AccountHolderId) AS r ON r.AccountHolderId = a.Id
		WHERE r.totalBalance > @Number
	ORDER BY FirstName,LastName
END
