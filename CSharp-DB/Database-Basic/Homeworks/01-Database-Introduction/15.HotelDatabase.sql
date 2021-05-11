CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Title VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Employees VALUES
('Toto H','Luchezarov','Singer','The BEST!!'),
('Dimitar','MIRONOFF','Singer',NULL),
('Grisho','Grozdanow','Mechanic','He know what is doing')


CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	PhoneNumber VARCHAR(10) NOT NULL,
	EmergencyName VARCHAR(100) NOT NULL,
	EmergencyNumber VARCHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Customers VALUES
(895215,'Gosho','Peshow','0895163547','Tosho','0896874563',NULL),
(894268,'Tosho','Peshow','0896874563','Ico','0897459871',NULL),
(632548,'Ico','Peshow','0897459871','Gosho','0895163547',NULL)


CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO RoomStatus VALUES
('Cleaning',NULL),
('Ready For Guests',NULL),
('Busy',NULL)


CREATE TABLE RoomTypes 
(
	RoomType VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO RoomTypes VALUES
('Two bedroom',NULL),
('Single bedroom',NULL),
('Apartment',NULL)


CREATE TABLE BedTypes 
(
	BedType VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO BedTypes VALUES
('Singel bed',NULL),
('Double bed',NULL),
('Child bed',NULL)


CREATE TABLE Rooms 
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(100) NOT NULL,
	BedType VARCHAR(100) NOT NULL,
	Rate DECIMAL(10,2),
	RoomStatus VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Rooms VALUES
(101,'Single bedroom','Singel bed',NULL,'Busy',NULL),
(102,'Two bedroom','Double bed',NULL,'Cleaning',NULL),
(103,'Apartment','Child bed',NULL,'Ready For Guests',NULL)


CREATE TABLE Payments 
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(38,2) NOT NULL,
	TaxRate DECIMAL(38,2) NOT NULL,
	TaxAmount DECIMAL(38,2) NOT NULL,
	PaymentTotal DECIMAL(38,2) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Payments VALUES
(1,GETDATE(),632548,GETDATE(),GETDATE(),10,236.69,563.23,189.36,25698,NULL),
(2,GETDATE(),894268,GETDATE(),GETDATE(),10,236.69,563.23,189.36,25698,NULL),
(3,GETDATE(),895215,GETDATE(),GETDATE(),10,236.69,563.23,189.36,25698,NULL)


CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(10,2),
	PhoneCharge DECIMAL(10,2),
	Notes VARCHAR(MAX)
)
INSERT INTO Occupancies VALUES
(1,GETDATE(),895215,101,7.96,NULL,NULL),
(2,GETDATE(),632548,102,NULL,2.56,NULL),
(3,GETDATE(),894268,103,9.6,0.65,'We will back')
SELECT * FROM Occupancies