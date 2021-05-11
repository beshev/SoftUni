CREATE DATABASE SofUni

--Towns (Id, Name)
CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL
)

--•	Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

--•	Departments (Id, Name)
CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL
)

--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(100) NOT NULL,
	MiddleName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	JobTitle VARCHAR(100) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(30,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
)