SELECT r.[Email Provider],COUNT(*)
 FROM (SELECT SUBSTRING(Email,CHARINDEX('@',Email) + 1, LEN(Email) - (CHARINDEX('@',Email) - 1 )) AS [Email Provider]
	FROM Users) AS r
GROUP BY r.[Email Provider]
ORDER BY COUNT(r.[Email Provider]) DESC,r.[Email Provider]
