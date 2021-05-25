CREATE VIEW v_UserWithCountries AS 
SELECT CONCAT(c.FirstName,' ',c.LastName) AS CustomerName,
	   c.Age,
	   c.Gender,
	   ct.Name
	FROM Customers AS c
	JOIN Countries AS ct ON ct.Id = c.CountryId
