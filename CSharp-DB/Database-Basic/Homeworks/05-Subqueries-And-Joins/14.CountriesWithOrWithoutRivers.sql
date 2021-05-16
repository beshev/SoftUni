SELECT TOP(5) c.CountryName,r.RiverName
	FROM Countries c
	LEFT JOIN CountriesRivers cs ON cs.CountryCode = c.CountryCode
	LEFT JOIN Rivers r ON r.Id = cs.RiverId
  WHERE c.ContinentCode = 'AF'
  ORDER BY c.CountryName