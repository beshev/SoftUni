SELECT a.FirstName,a.LastName,FORMAT(a.BirthDate,'MM-dd-yyyy'),c.Name,a.Email
	FROM Accounts AS a
	JOIN Cities AS c ON c.Id = a.CityId
	WHERE Email LIKE 'e%'
ORDER BY c.Name