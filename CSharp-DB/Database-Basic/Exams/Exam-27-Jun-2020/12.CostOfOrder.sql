CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN 
	DECLARE @Result DECIMAL(15,2) = 
	(
		SELECT SUM(pr.Price)
			FROM Jobs AS j
		 	LEFT JOIN Orders AS o ON o.JobId = j.JobId
			LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
			LEFT JOIN Parts AS pr ON pr.PartId = op.PartId
		WHERE j.JobId = @JobId
		GROUP BY j.JobId
	)

	IF @Result IS NULL
	 SET @Result = 0

	RETURN @Result
END