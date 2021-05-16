SELECT result.ContinentCode,result.CurrencyCode,result.[Count]
   FROM (SELECT c.ContinentCode,
	   c.CurrencyCode,COUNT(c.CurrencyCode) AS [Count],
	   DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [rank] 
	FROM Countries AS c	
 GROUP BY c.ContinentCode,c.CurrencyCode) AS result
 WHERE result.[rank] = 1 AND result.[Count] > 1