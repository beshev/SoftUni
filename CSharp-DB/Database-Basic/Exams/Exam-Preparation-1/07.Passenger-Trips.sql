SELECT 
	CONCAT(p.FirstName,' ',p.LastName) AS FullName
	,f.Origin
	,f.Destination
	FROM Passengers AS p
	JOIN Tickets AS t ON t.PassengerId = p.Id
	JOIN Flights AS f ON f.Id = t.FlightId
	ORDER BY FullName,f.Origin,f.Destination