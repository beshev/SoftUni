SELECT a.AgeGroup,COUNT(a.AgeGroup) AS WizardCount
	FROM (SELECT CASE  
	    WHEN Age BETWEEN 0 AND 10 then '[0-10]'
	    WHEN Age BETWEEN 11 AND 20 then '[11-20]'
		WHEN Age BETWEEN 21 AND 30 then '[21-30]'
		WHEN Age BETWEEN 31 AND 40 then '[31-40]'
		WHEN Age BETWEEN 41 AND 50 then '[41-50]'
		WHEN Age BETWEEN 51 AND 60 then '[51-60]'
	    else '[61+]' END AS AgeGroup
		FROM WizzardDeposits) AS a
 GROUP BY a.AgeGroup