CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(18,2))
RETURNS VARCHAR(MAX) AS 
BEGIN
	IF(@grade > 6.00)
		RETURN 'Grade cannot be above 6.00!'
	IF(NOT EXISTS (SELECT 1 FROM Students WHERE Id = @studentId))
		RETURN 'The student with provided id does not exist in the school!'

	DECLARE @GradesCount INT = (SELECT COUNT(*) FROM StudentsExams WHERE StudentId = @studentId AND Grade BETWEEN @grade AND (@grade + 0.50))

	DECLARE @FirstName NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	RETURN CONCAT('You have to update ', @GradesCount, ' grades for the student ', @FirstName)
END

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)