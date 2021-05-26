SELECT a.Id,a.Email,c.Name AS City,COUNT(t.Id) AS Trips
	FROM Accounts AS a
	JOIN AccountsTrips AS tr ON tr.AccountId = a.Id
	JOIN Trips AS t ON t.Id = tr.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c ON c.Id = A.CityId
	WHERE h.CityId = a.CityId
	GROUP BY a.Id,a.Email,c.Name
ORDER BY Trips DESC,a.Id