SELECT *
	FROM (SELECT t.JobDuringJourney,
	CONCAT(c.FirstName,' ',c.LastName) AS FullName,
	DENSE_RANK() OVER (PARTITION BY t.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
	FROM Colonists AS c
	JOIN TravelCards AS t ON t.ColonistId = c.Id) AS r
 WHERE r.JobRank = 2