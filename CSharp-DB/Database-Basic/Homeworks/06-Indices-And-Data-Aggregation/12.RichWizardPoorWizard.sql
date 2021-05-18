SELECT SUM(r.Difference) 
 FROM (SELECT FirstName
	   , DepositAmount
	   ,LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard]
	   ,LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit]
	   ,DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS [Difference]
	FROM WizzardDeposits) AS r