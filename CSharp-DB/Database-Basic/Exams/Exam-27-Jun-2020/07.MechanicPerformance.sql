SELECT r.FirstName+ ' ' + r.LastName AS Mechanic,AVG(r.[Days]) AS [Average Days]
 	FROM (SELECT m.MechanicId,m.FirstName,m.LastName,DATEDIFF(DAY,j.IssueDate,j.FinishDate) AS [Days]
		FROM Mechanics AS m
		JOIN Jobs AS j ON j.MechanicId = m.MechanicId) AS r
 GROUP BY r.FirstName,r.LastName,r.MechanicId
 ORDER BY r.MechanicId