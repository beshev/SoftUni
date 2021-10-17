CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(30)) 
RETURNS INT AS 
BEGIN
	RETURN (SELECT COUNT(*)
		FROM Clients AS c
		JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
		WHERE c.FirstName = @name)
END