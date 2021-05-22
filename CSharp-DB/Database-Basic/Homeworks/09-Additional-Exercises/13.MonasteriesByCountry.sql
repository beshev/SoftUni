CREATE TABLE Monasteries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')


UPDATE Countries
	SET IsDeleted = 1
	WHERE CountryCode IN 
	(
		SELECT cr.CountryCode FROM CountriesRivers AS cr
			GROUP BY cr.CountryCode
			HAVING COUNT(cr.RiverId) > 3
	)

SELECT m.[Name] AS Monastery,cr.CountryName AS Country
	FROM Monasteries AS m
	JOIN Countries AS cr ON cr.CountryCode = m.CountryCode
	WHERE cr.IsDeleted = 0
 ORDER BY m.[Name]
