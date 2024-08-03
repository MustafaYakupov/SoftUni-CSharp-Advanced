CREATE DATABASE Boardgames 

GO

USE Boardgames

GO

-- Problem 01 DDL
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY
	,StreetName VARCHAR(100) NOT NULL
	,StreetNumber INT NOT NULL
	,Town VARCHAR(30) NOT NULL
	,Country VARCHAR(50) NOT NULL
	,ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) NOT NULL UNIQUE
	,AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
	,Website VARCHAR(40)
	,Phone VARCHAR(20)
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY
	,PlayersMin INT NOT NULL
	,PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(30) NOT NULL 
	,YearPublished INT NOT NULL
	,Rating DECIMAL(3, 2) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL
	,PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(30) NOT NULL 
	,LastName NVARCHAR(30) NOT NULL 
	,Email NVARCHAR(30) NOT NULL 
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT FOREIGN KEY REFERENCES Creators(Id)
	,BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id)
	,PRIMARY KEY(CreatorId, BoardgameId)
)

GO

--Problem 02
INSERT INTO Boardgames([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES 
	('Deep Blue', 2019, 5.67, 1, 15, 7)
	,('Paris', 2016, 9.78, 7, 1, 5)
	,('Catan: Starfarers', 2021, 9.87, 7, 13, 6)
	,('Bleeding Kansas', 2020, 3.25, 3, 7, 4)
	,('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers([Name], AddressId, Website, Phone)
VALUES 
	('Agman Games', 5, 'www.agmangames.com', '+16546135542')
	,('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992')
	,('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

GO

-- Problem 03
UPDATE PlayersRanges
SET PlayersMax = PlayersMax + 1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET [Name] = CONCAT([Name], 'V2')
WHERE YearPublished >= 2020

GO

-- Problem 04

SELECT *
FROM Addresses
WHERE Town LIKE 'L%'

SELECT *
FROM Publishers
WHERE AddressId = 5

SELECT *
FROM Boardgames
WHERE PublisherId = 1

SELECT *
FROM CreatorsBoardgames
WHERE BoardgameId IN (1, 16, 31)

DELETE 
FROM CreatorsBoardgames 
WHERE BoardgameId IN (1,16,31,47)

DELETE 
FROM Boardgames 
WHERE PublisherId IN (1,16)

DELETE 
FROM Publishers 
WHERE AddressId IN (5)

DELETE 
FROM Addresses
WHERE Town LIKE 'L%'

GO

-- Problem 05
SELECT 
	[Name]
	,Rating
FROM Boardgames
ORDER BY YearPublished, [Name] DESC

GO

-- Problem 06
SELECT 
	b.Id
	,b.[Name]
	,b.YearPublished
	,c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON b.CategoryId = c.Id
WHERE c.[Name] =  'Strategy Games' OR c.[Name] = 'Wargames'
ORDER BY b.YearPublished DESC

GO

-- Problem 07
SELECT 
	c.Id
	,CONCAT_WS(' ', c.FirstName, c.LastName) AS CreatorName
	,c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
LEFT JOIN Boardgames AS b ON cb.BoardgameId = b.Id
WHERE cb.BoardgameId IS NULL
ORDER BY c.[FirstName]

GO

-- Problem 08
SELECT TOP(5)
	b.[Name]
	,b.Rating
	,c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
JOIN Categories AS c ON c.Id = b.CategoryId
WHERE b.Rating > 7.00 AND b.[Name] LIKE '%a%'
OR b.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5
ORDER BY b.[Name], b.Rating DESC

GO

-- Problem 09
SELECT 
	CONCAT_WS(' ', c.FirstName, c.LastName) AS FullName
	,c.Email
	,MAX(b.Rating) AS Rating
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
WHERE c.Email LIKE '%.com'
GROUP BY CONCAT_WS(' ', c.FirstName, c.LastName), c.Email
ORDER BY CONCAT_WS(' ', c.FirstName, c.LastName) 

GO

-- Problem 10
SELECT 
	c.LastName
	,CEILING(AVG(b.Rating)) AS AverageRating
	,p.[Name] AS PublisherName
FROM Creators AS c 
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
JOIN Publishers AS p ON p.Id = b.PublisherId
WHERE p.[Name] =  'Stonemaier Games'
GROUP BY  c.LastName, p.[Name]
ORDER BY AVG(b.Rating) DESC

GO

-- Problem 11
CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(50)) 
RETURNS INT AS
BEGIN
	DECLARE @totatlAmountOfBoardgames INT
	SET @totatlAmountOfBoardgames = 
	(
		SELECT COUNT(*) 
		FROM Creators AS c 
		JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
		JOIN Boardgames AS b ON cb.BoardgameId = b.Id 
		WHERE c.FirstName = @name
	)

	RETURN @totatlAmountOfBoardgames
END

SELECT dbo.udf_CreatorWithBoardgames('Bruno')

GO

-- Problem 12
CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
AS
BEGIN
	SELECT 
		b.[Name]
		,b.YearPublished
		,b.Rating
		,c.[Name] AS CategoryName
		,p.[Name] AS PublisherName
		,CONCAT_WS(' ', pr.PlayersMin, 'people') AS MinPlayers
		,CONCAT_WS(' ', pr.PlayersMax, 'people') AS MaxPlayers
	FROM Boardgames AS b
	JOIN Categories AS c ON c.Id = b.CategoryId
	JOIN Publishers AS p ON p.Id = b.PublisherId
	JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
	WHERE c.[Name] = @category
	ORDER BY p.[Name], b.YearPublished DESC
END

EXEC usp_SearchByCategory 'Wargames'

GO









