CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
BEGIN
	DECLARE @clientCigars INT = (
	SELECT
		COUNT(c.Id)
	FROM Clients c
	JOIN ClientsCigars cc ON c.Id=cc.ClientId
	WHERE c.FirstName = @name
	)
	RETURN @clientCigars
END