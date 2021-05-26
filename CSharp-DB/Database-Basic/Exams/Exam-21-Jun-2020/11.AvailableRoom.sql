CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN 
	DECLARE @RoomId INT = 
	(
		SELECT TOP(1) r.Id 
			FROM Rooms AS r
			JOIN Trips AS t ON t.RoomId = r.Id
			WHERE r.HotelId = @HotelId 
				  AND r.Beds > @People
				  AND ((@Date >= t.ArrivalDate AND @Date <= t.ReturnDate AND t.CancelDate IS NOT NULL) 
				  OR (@Date < t.ArrivalDate OR @Date > t.ReturnDate))
			ORDER BY r.Price DESC

	)

	IF(SELECT COUNT(Id) FROM Rooms WHERE Id = @RoomId) < 1
		RETURN 'No rooms available'

	DECLARE @HotelBaseRate DECIMAL(15,2) = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
	DECLARE @RoomPrice DECIMAL(15,2) = (SELECT Price FROM Rooms WHERE Id = @RoomId)
	DECLARE @RoomType NVARCHAR(MAX) = (SELECT [Type] FROM Rooms WHERE Id = @RoomId)
	DECLARE @RoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @RoomId)
	DECLARE @TotalPrice DECIMAL(15,2) = (@HotelBaseRate + @RoomPrice) * @People

	RETURN CONCAT('Room ',@RoomId,': ',@RoomType,' (',@RoomBeds,' beds) - $',@TotalPrice)
END