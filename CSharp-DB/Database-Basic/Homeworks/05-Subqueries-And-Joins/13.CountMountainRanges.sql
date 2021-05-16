SELECT c.CountryCode,
	   (SELECT COUNT(*) FROM MountainsCountries mc WHERE c.CountryCode = mc.CountryCode) AS MountainRanges
	FROM Countries AS c 
 WHERE c.CountryCode IN ('BG','US','RU')


 SELECT mc.CountryCode,COUNT(mc.CountryCode) AS MountainRanges
	FROM MountainsCountries AS mc
	JOIN Countries AS c ON c.CountryCode = mc.CountryCode
	WHERE c.CountryCode IN ('BG','RU','US')
  GROUP BY mc.CountryCode