SELECT f.ProductId,f.Rate,f.Description,f.CustomerId,c.Age,c.Gender
	FROM Feedbacks AS f
	JOIN Customers AS c ON c.Id = f.CustomerId
	WHERE f.Rate < 5.0
 ORDER BY f.ProductId DESC,f.Rate