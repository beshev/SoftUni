CREATE PROC usp_PlaceOrder @JobId INT , @PartSerialNumber VARCHAR(50) ,@Quantity INT
AS
BEGIN
	DECLARE @Status VARCHAR(11) = (SELECT [Status] FROM Jobs WHERE JobId = @JobId)
	IF (@Quantity <= 0)
		THROW 50012,'Part quantity must be more than zero!',1
	ELSE IF (NOT EXISTS(SELECT JobId FROM Jobs WHERE JobId = @JobId))
		THROW 50013,'Job not found!',1
	ELSE IF (@Status = 'Finished')
		THROW 50011,'This job is not active!',1
	ELSE IF (NOT EXISTS(SELECT PartId FROM Parts WHERE SerialNumber = @PartSerialNumber))
		THROW 50014,'Part not found!',1

	IF((SELECT COUNT(*) FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL) <> 1)
	BEGIN
		INSERT INTO Orders(JobId,IssueDate) VALUES
		(@JobId,NULL)
	END

	DECLARE @OrderId INT = (SELECT OrderId FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL)
	DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @PartSerialNumber)

	IF((SELECT COUNT(*) FROM OrderParts WHERE OrderId = @OrderId AND PartId = @PartId) <> 1)
	BEGIN
		INSERT INTO OrderParts VALUES
		(@OrderId,@PartId,@Quantity)
	END
	ELSE 
	BEGIN
		UPDATE OrderParts
			SET Quantity += @Quantity
			WHERE OrderId = @OrderId AND PartId = @PartId
	END

END

