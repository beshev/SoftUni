CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(50))
RETURNS INT AS
BEGIN
	RETURN (
				SELECT COUNT(c.Id)
					FROM Users AS u 
					LEFT JOIN Commits AS c ON c.ContributorId = u.Id
					WHERE u.Username = @username
			)
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')