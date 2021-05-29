SELECT c.Id,CONCAT(c.FirstName,' ',c.LastName)
	FROM Colonists AS c
	JOIN TravelCards AS t ON t.ColonistId = c.Id
  WHERE t.JobDuringJourney = 'pilot'
ORDER BY c.Id