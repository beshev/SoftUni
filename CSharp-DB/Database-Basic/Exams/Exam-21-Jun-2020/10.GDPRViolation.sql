SELECT  t.Id,
		CONCAT(a.FirstName,' ',ISNULL(a.MiddleName + ' ',''),a.LastName) AS FullName,
		accountCity.Name AS [From],
		hotelCity.Name AS [To],
		CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE
			CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate),' days')		
		END
	FROM Trips as t
	JOIN AccountsTrips AS at ON at.TripId = t.Id
	JOIN Accounts AS a ON a.Id = at.AccountId
	JOIN Cities AS accountCity ON accountCity.Id = a.CityId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS hotelCity ON hotelCity.Id = h.CityId
ORDER BY FullName,t.Id