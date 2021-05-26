SELECT c.Name, COUNT(h.CityId)
	FROM Cities AS c
	JOIN Hotels AS h ON h.CityId = c.Id
 GROUP BY c.Name
 ORDER BY COUNT(h.CityId) DESC,c.Name