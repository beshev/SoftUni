SELECT c.FirstName + ' ' + c.LastName AS Client,DATEDIFF(DAY, j.IssueDate,'2017-04-24'),j.Status
	FROM Jobs AS j
	JOIN Clients AS c ON c.ClientId = j.ClientId
	WHERE j.[Status] != 'Finished'