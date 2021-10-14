SELECT sub.[Name], AVG(ss.Grade)
	FROM Subjects AS sub
	JOIN StudentsSubjects AS ss ON ss.SubjectId = sub.Id
	GROUP BY sub.Id,sub.[Name]
	ORDER BY sub.Id