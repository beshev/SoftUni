CREATE PROC usp_WithdrawMoney @AccountId DECIMAL(18,4),@MoneyAmount DECIMAL(18,4)
AS
BEGIN TRANSACTION
	IF NOT EXISTS(SELECT * FROM Accounts WHERE Id = @AccountId)
		ROLLBACK;
	IF (@AccountId) <= 0
		ROLLBACK;
	UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @AccountId
COMMIT

EXEC usp_WithdrawMoney 5,25
SELECT * FROM Accounts