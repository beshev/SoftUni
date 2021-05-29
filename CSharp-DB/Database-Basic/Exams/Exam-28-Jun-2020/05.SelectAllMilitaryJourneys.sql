SELECT Id,FORMAT(JourneyStart,'dd/MM/yyyy'),FORMAT(JourneyEnd,'dd/MM/yyyy')
	FROM Journeys
	WHERE Purpose = 'Military'
ORDER BY JourneyStart