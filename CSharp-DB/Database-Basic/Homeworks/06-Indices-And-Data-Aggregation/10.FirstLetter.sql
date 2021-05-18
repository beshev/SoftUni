SELECT LEFT(w.FirstName,1) AS FirstLetter
	FROM WizzardDeposits w
	WHERE DepositGroup = 'Troll Chest'
 GROUP BY LEFT(w.FirstName,1)
 ORDER BY FirstLetter