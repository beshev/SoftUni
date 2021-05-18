SELECT DepositGroup
   FROM  (SELECT DepositGroup,AVG(MagicWandSize) AS AvgWandSize,DENSE_RANK() OVER (ORDER BY AVG(MagicWandSize)) AS [Rank]
		 	FROM WizzardDeposits
		  GROUP BY DepositGroup) AS r
WHERE r.[Rank] = 1