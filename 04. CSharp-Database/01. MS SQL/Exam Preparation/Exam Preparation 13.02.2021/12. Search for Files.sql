CREATE PROC usp_SearchForFiles(@fileExtension NVARCHAR(30))
AS
BEGIN
	DECLARE @lengthOfFileExtension INT = LEN(@fileExtension)
	SELECT
		Id,
		Name,
		CAST(Size AS VARCHAR(30)) + 'KB' AS Size
	FROM Files
	WHERE RIGHT(Name, @lengthOfFileExtension) = @fileExtension
	ORDER BY Id ASC, Name ASC, Size DESC
END

EXEC usp_SearchForFiles 'txt'