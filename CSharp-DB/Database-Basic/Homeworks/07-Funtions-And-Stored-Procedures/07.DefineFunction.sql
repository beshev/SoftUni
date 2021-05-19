CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1
	WHILE (LEN(@word) >= @i)
		BEGIN
			DECLARE @Result BIT = 
			LEN((SELECT @setOfLetters WHERE @setOfLetters LIKE '%' + SUBSTRING(@word,@i,1) + '%'))
			IF @Result IS NULL
				RETURN 0
			SET @i += 1
		END
	RETURN 1
END