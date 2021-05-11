CREATE TABLE Directors(
Id INT IDENTITY(1,1) PRIMARY KEY,
DirectorName VARCHAR(50) NOT NULL,
Notes VARCHAR(50)
);

INSERT INTO Directors(DirectorName,Notes) VALUES
('Gosho',NULL),
('Pesho',NULL),
('Toto','The inspirer'),
('Toshko',NULL),
('Milka','True Warrior')

CREATE TABLE Genres(
Id INT IDENTITY(1,1) PRIMARY KEY,
GenreName VARCHAR(50) NOT NULL,
Notes VARCHAR(50)
);

INSERT INTO Genres(GenreName,Notes) VALUES
('Horror','Be Careful!!'),
('Comedy',NULL),
('Action','Dont stop!'),
('Fantasy',NULL),
('Family','Time to cohesion')

CREATE TABLE Categories(
Id INT IDENTITY(1,1) PRIMARY KEY,
CategoryName VARCHAR(50) NOT NULL,
Notes VARCHAR(50)
);

INSERT INTO Categories(CategoryName,Notes) VALUES
('For Àdults','Be Careful!!'),
('Under 18',NULL),
('Animation','Just child'),
('Above 18',NULL),
('Test','This is just a test')

CREATE TABLE Movies(
Id INT IDENTITY(1,1) PRIMARY KEY,
Title VARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear SMALLINT NOT NULL,
Length SMALLINT,
GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Rating SMALLINT,
Notes VARCHAR(50) 
);

INSERT INTO Movies(Title,DirectorId,CopyrightYear,Length,GenreId,CategoryId,Rating,Notes) VALUES
('Big Bad Daddies',1,2017,NULL,4,1,NULl,NULL),
('Fast and Furions',2,2000,NULL,3,4,NULl,NULL),
('Big Stan',3,2015,NULL,2,2,NULl,NULL),
('The Wall',4,2018,NULL,5,5,NULl,NULL),
('Horror Parody',5,2017,NULL,1,3,NULl,NULL)