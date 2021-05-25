SELECT d.Name,i.Name,p.Name,AVG(f.Rate) AS AverageRate
	FROM ProductsIngredients AS pi
	JOIN Ingredients AS i ON i.Id = pi.IngredientId
	JOIN Products AS p ON p.Id = pi.ProductId
	JOIN Distributors AS d ON d.Id = i.DistributorId
	JOIN Feedbacks AS f ON f.ProductId = p.Id
 GROUP BY d.Name,i.Name,p.Name
 HAVING AVG(f.Rate) BETWEEN 5 AND 8
 ORDER BY d.Name,i.Name,p.Name