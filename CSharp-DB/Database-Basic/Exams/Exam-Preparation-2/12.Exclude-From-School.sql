CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	IF(NOT EXISTS (SELECT 1 FROM Students WHERE Id = @StudentId))
		 RAISERROR('This school has no student with the provided id!',16,1)

	DELETE FROM StudentsExams
		WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
		WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
		WHERE StudentId = @StudentId

	DELETE FROM Students
		WHERE Id = @StudentId
END

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301