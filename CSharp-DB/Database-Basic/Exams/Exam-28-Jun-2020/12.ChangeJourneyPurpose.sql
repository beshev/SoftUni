CREATE PROC usp_ChangeJourneyPurpose @JourneyId INT , @NewPurpose VARCHAR(11)
AS
	IF(NOT EXISTS(SELECT * FROM Journeys WHERE Id = @JourneyId ))
	BEGIN
		RAISERROR('The journey does not exist!',16,1)
		RETURN
	END

	IF(EXISTS(SELECT * FROM Journeys WHERE Id = @JourneyId AND Purpose = @NewPurpose))
	BEGIN
		RAISERROR('You cannot change the purpose!',16,1)
		RETURN
	END

	UPDATE Journeys
		SET Purpose = @NewPurpose
		WHERE Id = @JourneyId