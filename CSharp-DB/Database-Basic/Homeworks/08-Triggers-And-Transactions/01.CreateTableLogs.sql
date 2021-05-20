CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId,OldSum,NewSum)
	SELECT i.Id,d.Balance,i.Balance FROM inserted AS i
	JOIN deleted AS d ON d.Id = i.Id
	WHERE i.Balance != d.Balance
END