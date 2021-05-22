SELECT p.PeakName,m.MountainRange,cr.CountryName,cn.ContinentName
	FROM Peaks AS p
	JOIN Mountains AS m ON m.Id = p.MountainId
	JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
	JOIN Countries AS cr ON cr.CountryCode = mc.CountryCode
	JOIN Continents AS cn ON cn.ContinentCode = cr.ContinentCode
ORDER BY p.PeakName,cr.CountryName