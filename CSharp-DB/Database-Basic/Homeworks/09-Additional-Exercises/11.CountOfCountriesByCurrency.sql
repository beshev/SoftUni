SELECT cr.CurrencyCode,cr.[Description] AS [Currency],COUNT(ct.CountryName) AS NumberOfCountries
	FROM Currencies AS cr
	LEFT JOIN Countries AS ct ON ct.CurrencyCode = cr.CurrencyCode
GROUP BY cr.CurrencyCode,cr.[Description]
ORDER BY NumberOfCountries DESC, [Currency]