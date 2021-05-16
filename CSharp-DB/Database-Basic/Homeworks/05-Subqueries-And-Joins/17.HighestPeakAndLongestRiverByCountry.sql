SELECT TOP(5) r.CountryName,r.HighestPeakElevation,r.LongestRiverLength
	FROM (SELECT c.CountryName, MAX(p.Elevation) AS HighestPeakElevation,MAX(r.Length) AS LongestRiverLength
   		FROM Countries  AS c
   		FULL JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
   		FULL JOIN Mountains AS m ON m.Id = mc.MountainId
   		FULL JOIN Peaks AS p ON p.MountainId = m.Id
   		FULL JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
   		FULL JOIN Rivers AS r ON r.Id = cr.RiverId
 GROUP BY c.CountryName) AS r
 ORDER BY r.HighestPeakElevation DESC , r.LongestRiverLength DESC,r.CountryName