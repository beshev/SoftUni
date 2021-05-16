SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation
	FROM Countries AS c
	JOIN MountainsCountries AS ms ON ms.CountryCode = c.CountryCode
	JOIN Mountains AS m ON m.Id = ms.MountainId
	JOIN Peaks AS p ON p.MountainId = m.Id
 WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
 ORDER BY p.Elevation DESC