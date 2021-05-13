CREATE TABLE Students
(
	StudentID INT NOT NULL,
	[Name] NVARCHAR(50)
)

INSERT INTO Students VALUES
	(1,'Mila'),
	(2,'Toni'),
	(3,'Ron')

ALTER TABLE Students
ADD PRIMARY KEY (StudentID)

CREATE TABLE Exams
(
	ExamID INT NOT NULL,
	[Name] NVARCHAR(50)
)

INSERT INTO Exams VALUES
	(101,'SpringMVC'),
	(102,'Neo4j'),
	(103,'Oracle 11g')

ALTER TABLE Exams
ADD PRIMARY KEY (ExamID)

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
)

ALTER TABLE StudentsExams
ADD PRIMARY KEY(StudentID,ExamID)

ALTER TABLE StudentsExams
ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

ALTER TABLE StudentsExams
ADD FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)