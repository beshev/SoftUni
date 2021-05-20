CREATE TRIGGER tr_EmailWhenNewRecordIsInserted
ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails(Recipient,[Subject],Body)
	SELECT i.AccountId,
		   N'Balance change for account: ' 
		   + CAST(i.AccountId AS nvarchar),
		   N'On '
		   + CAST(GETDATE() AS nvarchar) 
		   + N' your balance was changed from ' 
		   + CAST(i.OldSum AS nvarchar) 
		   + N' to ' +  CAST(i.NewSum AS nvarchar)
		FROM inserted AS i
END