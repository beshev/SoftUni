SELECT FlightId, SUM(Price) AS Price
	FROM Tickets
	GROUP BY FlightId
	ORDER BY Price DESC,FlightId