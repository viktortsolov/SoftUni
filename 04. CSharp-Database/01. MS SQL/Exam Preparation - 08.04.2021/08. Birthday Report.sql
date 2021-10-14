SELECT 
		u.Username,
		c.Name 
	FROM Reports AS r
	LEFT JOIN Users AS u ON r.UserId = u.Id
	LEFT JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE DAY(r.OpenDate) = DAY(u.Birthdate)
  ORDER BY u.Username, c.Name