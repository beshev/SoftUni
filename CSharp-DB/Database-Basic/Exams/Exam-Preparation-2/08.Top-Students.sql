SELECT TOP(10) s.FirstName,s.LastName, CAST(AVG(sx.Grade) AS DECIMAL(18,2)) AS Grade
	FROM Students AS s
	JOIN StudentsExams AS sx ON sx.StudentId = s.Id
	GROUP BY s.FirstName,s.LastName
	ORDER BY Grade DESC,s.FirstName,s.LastName