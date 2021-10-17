SELECT 
	CONCAT(c.FirstName,' ',c.LastName) AS FullName
	,a.Country
	,a.ZIP
	,CONCAT('$',MAX(ci.PriceForSingleCigar)) AS CigarPrice
	FROM Clients AS c
	JOIN Addresses AS a ON a.Id = c.AddressId
	JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
	JOIN Cigars AS ci ON ci.Id = cc.CigarId
	WHERE a.ZIP NOT LIKE '%[A-Za-z]%'
	GROUP BY c.FirstName,c.LastName,a.ZIP,a.Country
	ORDER BY FullName