CREATE TABLE Users(
Id INT IDENTITY(1,1) PRIMARY KEY,
Username CHAR(30) UNIQUE NOT NULL,
Password CHAR(26) NOT NULL,
ProfilePicture INT,
LastLoginTIime DATETIME,
IsDeleted BIT
);

INSERT INTO Users(Username,Password) VALUES
('Gogo','SipiO6teEnda'),
('Pesho','BugBe'),
('Toto','YesBaby'),
('EmiNema','SipiPak'),
('Metin','NaiSeriozniq')
