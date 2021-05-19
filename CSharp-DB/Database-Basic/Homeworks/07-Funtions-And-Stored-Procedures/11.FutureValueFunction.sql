CREATE FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(18,4),@Yearly FLOAT,@Years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	RETURN (@Sum * (POWER((1 + @Yearly),@Years)))
END
