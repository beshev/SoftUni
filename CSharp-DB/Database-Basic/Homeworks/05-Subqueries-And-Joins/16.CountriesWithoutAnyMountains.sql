SELECT COUNT(*) AS [Count]
	FROM Countries c
	LEFT JOIN MountainsCountries m ON m.CountryCode = c.CountryCode
 WHERE m.MountainId IS NULL
