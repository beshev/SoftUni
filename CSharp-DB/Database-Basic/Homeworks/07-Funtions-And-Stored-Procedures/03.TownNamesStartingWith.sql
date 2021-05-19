CREATE PROC usp_GetTownsStartingWith  @TownLetter VARCHAR(50)
AS
BEGIN
	SELECT [Name] 
		FROM Towns
		WHERE [Name] LIKE @TownLetter + '%'
END