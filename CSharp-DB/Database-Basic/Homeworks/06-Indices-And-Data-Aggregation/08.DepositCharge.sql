SELECT w.DepositGroup,w.MagicWandCreator,MIN(w.DepositCharge)
	FROM WizzardDeposits AS w
GROUP BY w.DepositGroup,w.MagicWandCreator
ORDER BY w.MagicWandCreator,w.DepositGroup