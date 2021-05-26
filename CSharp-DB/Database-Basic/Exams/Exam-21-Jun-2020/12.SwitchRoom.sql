CREATE PROC usp_SwitchRoom @TripId INT , @TargetRoomId INT
AS 
BEGIN
	DECLARE @HotelTargetId INT  = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @TripRoomId INT = (SELECT RoomId FROM Trips WHERE Id = @TripId)
	DECLARE @TripHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TripRoomId)

	IF(@HotelTargetId <> @TripHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!',16,1)
		RETURN
	END

	DECLARE @TripsAcc INT = (SELECT COUNT(TripId) FROM AccountsTrips WHERE TripId = @TripId)
	IF(SELECT Beds FROM Rooms WHERE Id = @TargetRoomId) < @TripsAcc
	BEGIN
		RAISERROR('Not enough beds in target room!',16,1)
		RETURN
	END

	UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId

END 
