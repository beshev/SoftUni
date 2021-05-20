CREATE PROC usp_TransferMoney @SenderId INT,@ReceiverId INT,@MoneyAmount DECIMAL(18,4)
AS
BEGIN TRANSACTION
	EXEC usp_WithdrawMoney @SenderId,@MoneyAmount
	EXEC usp_DepositMoney @ReceiverId,@MoneyAmount
COMMIT