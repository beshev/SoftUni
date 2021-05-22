SELECT p.PeakName,m.MountainRange,p.Elevation
	FROM Mountains AS m
	JOIN Peaks AS p ON p.MountainId = m.Id
ORDER BY p.Elevation DESC,p.[PeakName]