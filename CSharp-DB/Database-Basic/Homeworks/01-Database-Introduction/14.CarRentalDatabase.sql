CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(90) NOT NULL,
	DailyRate DECIMAL(10,2),
	WeeklyRate DECIMAL(20,2),
	MonthlyRate DECIMAL(20,2),
	WeekendRate DECIMAL(20,2)
)
INSERT INTO Categories
(CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate) VALUES
('Sport',8.21,NULL,NUll,7.43),
('Family',1.33,4.56,8.76,10.00),
('Test',NULL,NULL,NUll,NULL)


CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(100) NOT NULL,
	Manufacturer VARCHAR(50) NOT NULL,
	Model VARCHAR(50) NOT NULL,
	CarYear CHAR(4) NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARCHAR(MAX),
	Condition VARCHAR(100) NOT NULL,
	Available BIT NOT NULL
)
INSERT INTO Cars VALUES
('TestCase1','TestCase1','TestCase1','2005',1,4,NULL,'Work',1),
('TestCase2','TestCase2','TestCase2','1998',2,3,NULL,'Work',0),
('TestCase1','TestCase1','TestCase1','2005',3,2,NULL,'Work',1)


CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(90) NOT NULL,
	Notes VARCHAR(90)
)
INSERT INTO Employees VALUES
('FistNameTestCase1','SecondNameTestCase1','FirstAndTheOnly',NULL),
('FistNameTestCase2','SecondNameTestCase2','SecondAndNotFirst',NULL),
('FistNameTestCase3','SecondNameTestCase3','ThirdIsNotLikeToFirst','Crying')


CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber VARCHAR(50) NOT NULL,
	FullName VARCHAR(90) NOT NULL,
	[Address] VARCHAR(90) NOT NULL,
	City VARCHAR(90) NOT NULL,
	ZIPCode VARCHAR(90) NOT NULL,
	Notes VARCHAR(90)
)
INSERT INTO Customers VALUES
('DriverLicence101','Gogo Petrow','Somewere In BG','Same Like Address','4046',NULL),
('DriverLicence202','Pesho Petrow','Somewere In BG','Same Like Address','4046',NULL),
('DriverLicence303','Lidia Petrowa','Somewere In BG','Same Like Address','4046',NULL)


CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT,
	RateApplied DECIMAL(2,2),

	TaxRate DECIMAL(2,2),
	OrderStatus VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO RentalOrders VALUES
(1,1,1,70,100000,200000,NULL,GETDATE(),'05/06/2022',NULL,NULL,NULL,'Succeeded','Drive carefully'),
(2,2,2,70,100000,200000,NULL,GETDATE(),'05/06/2022',NULL,NULL,NULL,'Succeeded',NULL),
(3,3,3,70,100000,200000,NULL,GETDATE(),'05/06/2022',NULL,NULL,NULL,'Succeeded',NULL)