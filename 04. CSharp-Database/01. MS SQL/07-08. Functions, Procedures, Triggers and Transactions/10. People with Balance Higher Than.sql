CREATE PROC usp_GetHoldersWithBalanceHigherThan @money MONEY
AS
BEGIN
	SELECT
		FirstName AS [First Name],
		LastName AS [Last Name]
	FROM Accounts AS a
	JOIN AccountHolders AS ah
	ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @money
	ORDER BY [First Name], [Last Name]
END