CREATE PROC usp_GetTownsStartingWith @word VARCHAR(50)
AS
BEGIN
	SELECT
		[Name] AS Town
	FROM Towns 
	WHERE LEFT([Name], LEN(@word)) = @word
END