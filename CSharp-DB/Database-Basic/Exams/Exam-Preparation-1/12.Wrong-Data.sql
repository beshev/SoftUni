CREATE PROC usp_CancelFlights
AS 
BEGIN 
	UPDATE Flights
		SET ArrivalTime = NULL, DepartureTime = NULL
		WHERE DATEDIFF(DAY,ArrivalTime,DepartureTime) < 0 OR DATEDIFF(HOUR,ArrivalTime,DepartureTime) < 0
END