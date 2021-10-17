SELECT c.Id,CONCAT(c.FirstName,' ',c.LastName) AS ClientName,c.Email
	FROM Clients AS c
	LEFT JOIN ClientsCigars AS cg ON cg.ClientId = c.Id
	WHERE cg.CigarId IS NULL
	ORDER BY ClientName