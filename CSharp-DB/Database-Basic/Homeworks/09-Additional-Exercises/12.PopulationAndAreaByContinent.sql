SELECT c.ContinentName,
	   SUM(cr.AreaInSqKm) AS CountriesArea, 
	   SUM(CAST(cr.[Population] AS BIGINT)) AS CountriesPopulation
	FROM Continents AS c
	JOIN Countries AS cr ON cr.ContinentCode = c.ContinentCode
GROUP BY c.ContinentName
ORDER BY CountriesPopulation DESC