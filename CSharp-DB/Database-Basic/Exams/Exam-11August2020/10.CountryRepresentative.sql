SELECT r.CName,r.DName
	FROM (SELECT c.Name AS CName,r.Name AS DName,DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY r.count DESC) AS Rank
	FROM (SELECT *,(SELECT COUNT(*) FROM Ingredients AS i  WHERE i.DistributorId = d.Id) AS Count
	FROM Distributors AS d) AS r
 JOIN Countries AS c  ON c.Id = r.CountryId) AS r
 WHERE r.Rank = 1
 ORDER BY r.CName,r.DName