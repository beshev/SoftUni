SELECT CONCAT(FirstName,' ',LastName) AS CustomerName,PhoneNumber,Gender
	FROM Customers
	WHERE Id NOT IN (SELECT CustomerId FROM Feedbacks)
 ORDER BY Id 