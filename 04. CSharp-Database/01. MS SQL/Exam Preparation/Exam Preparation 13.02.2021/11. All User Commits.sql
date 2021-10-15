CREATE FUNCTION udf_AllUserCommits(@username NVARCHAR(30))
RETURNS INT
BEGIN
DECLARE @CommitsCount INT = 
	(
	SELECT
	COUNT(c.Id)
		FROM Commits c
		LEFT JOIN Users u ON c.ContributorId = u.Id
		WHERE u.Username = @username
	)
RETURN @CommitsCount
END