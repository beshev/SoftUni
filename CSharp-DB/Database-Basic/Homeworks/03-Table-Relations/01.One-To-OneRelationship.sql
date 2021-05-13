CREATE TABLE Persons
(
	PersonID INT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(7,2),
	PassportID INT UNIQUE NOT NULL,
)

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY NOT NULL,
	PassportNumber CHAR(8) NOT NULL,
)

INSERT INTO Persons VALUES 
	(1,'Roberto',43300,102),
	(2,'Tom',56100,103),
	(3,'Yana',60200,101)

INSERT INTO  Passports VALUES
	(101,'N34FG21B'),
	(102,'K65LO4R7'),
	(103,'ZE657QP2')

ALTER TABLE Persons
ADD PRIMARY KEY (PersonID);

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID);