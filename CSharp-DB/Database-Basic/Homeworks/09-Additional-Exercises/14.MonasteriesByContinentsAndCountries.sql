UPDATE Countries
	SET CountryName = 'Burma'
	WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries VALUES
('Hanga Abbey',(SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania')),
('Myin-Tin-Daik',(SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))

SELECT cn.ContinentName,cr.CountryName,COUNT(m.Id) AS MonasteriesCount
	FROM Continents AS cn
	JOIN Countries AS cr ON cr.ContinentCode = cn.ContinentCode
	LEFT JOIN Monasteries AS m ON m.CountryCode = cr.CountryCode
	WHERE cr.IsDeleted = 0
 GROUP BY cn.ContinentName,cr.CountryName
 ORDER BY MonasteriesCount DESC,cr.CountryName
