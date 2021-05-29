SELECT s.Name,s.Manufacturer
	FROM Colonists AS c
	JOIN TravelCards AS t ON t.ColonistId = c.Id
	JOIN Journeys AS j ON j.Id = t.JourneyId
	JOIN Spaceships AS s ON s.Id = j.SpaceshipId
 WHERE DATEDIFF(YEAR,BirthDate,'2019-01-01') < 30 AND t.JobDuringJourney = 'pilot'
 ORDER BY s.Name
