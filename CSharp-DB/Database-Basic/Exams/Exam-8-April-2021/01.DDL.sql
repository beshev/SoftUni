--CREATE DATABASE [Service]
--GO
--USE [Service]

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT CHECK(Age >= 14 AND Age <= 110) NOT NULL,
	Email VARCHAR(50) NOT NULL,
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT CHECK(Age >= 18 AND Age <= 110),
	DepartmentId INT REFERENCES Departments(Id) NOT NULL,
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT REFERENCES Departments(Id) NOT NULL,
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL,
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	StatusId INT REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT REFERENCES Users(Id) NOT NULL,
	EmployeeId INT REFERENCES Employees(Id),
)