SELECT w.DepositGroup,w.IsDepositExpired,AVG(w.DepositInterest)
	FROM WizzardDeposits AS w
	WHERE w.DepositStartDate > '1985-01-01'
 GROUP BY w.DepositGroup,w.IsDepositExpired
 ORDER BY w.DepositGroup DESC,w.IsDepositExpired