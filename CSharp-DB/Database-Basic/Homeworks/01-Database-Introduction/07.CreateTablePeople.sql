/****** Script for SelectTopNRows command from SSMS  ******/
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY(1,1),
Name NCHAR(200) NOT NULL,
Picture  VARBINARY(MAX),
Height DECIMAL(38,2),
Weight DECIMAL(38,2),
Gender CHAR(1) NOT NULL,
Birthdate DATE NOT NUll,
Biography NVARCHAR(MAX)
);

INSERT INTO People(Name,Gender,Birthdate) VALUES
('Pesho','M','1995-12-31'),
('Fami','F','1994-12-31'),
('Ico','M','1992-12-31'),
('Stefo','M','1991-12-31'),
('Maria','F','1990-12-31')