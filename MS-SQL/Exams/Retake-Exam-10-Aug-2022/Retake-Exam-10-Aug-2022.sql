CREATE DATABASE NationalTouristSitesOfBulgaria

GO

USE NationalTouristSitesOfBulgaria

Go

-- Problem 01 DDL
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Locations
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,Municipality VARCHAR(50) 
	,Province VARCHAR(50) 
)

CREATE TABLE Sites
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(100) NOT NULL
	,LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,Establishment VARCHAR(15) 
)

CREATE TABLE Tourists
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,Age INT CHECK (Age >= 0 AND Age <= 120) NOT NULL
	,PhoneNumber VARCHAR(20) NOT NULL
	,Nationality VARCHAR(30) NOT NULL
	,Reward VARCHAR(20)
)

CREATE TABLE SitesTourists
(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id)  NOT NULL
	,SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL
	,PRIMARY KEY(TouristId, SiteId)
)

CREATE TABLE BonusPrizes
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes
(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id)  NOT NULL
	,BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL
	,PRIMARY KEY(TouristId, BonusPrizeId)
)

-- Problem 02
INSERT INTO Tourists([Name], Age, PhoneNumber, Nationality, Reward)
VALUES 
	('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL)
	,('Peter Bosh', 48, '+447911844141', 'UK', NULL)
	,('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge')
	,('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge')
	,('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites([Name], LocationId, CategoryId, Establishment)
VALUES
	('Ustra fortress', 90, 7, 'X')
	,('Karlanovo Pyramids', 65, 7, NULL)
	,('The Tomb of Tsar Sevt', 63, 8, 'V BC')
	,('Sinite Kamani Natural Park', 17, 1, NULL)
	,('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

GO

-- Problem 03
UPDATE Sites
SET Establishment = 'not defined'
WHERE Establishment IS NULL

GO

--Problem 04
SELECT * 
FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'


SELECT * 
FROM TouristsBonusPrizes
WHERE BonusPrizeId = 5

DELETE 
FROM TouristsBonusPrizes
WHERE TouristId IN (18, 20)

DELETE
FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'

GO

-- Problem 05
SELECT 
	[Name]
	,Age
	,PhoneNumber
	,Nationality
FROM Tourists
ORDER BY Nationality, Age DESC, [Name]

GO

-- Problem 06
SELECT 
	s.[Name] AS Site
	,l.[Name] AS Location
	,s.Establishment
	,c.[Name] AS Category
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
JOIN Categories AS c ON c.Id = s.CategoryId
ORDER BY c.[Name] DESC, l.[Name], s.[Name] 

GO

-- Problem 07
SELECT 
	l.Province
	,l.Municipality
	,l.[Name] AS Location
	,COUNT(*) AS CountOfSites
FROM Locations AS l
JOIN Sites AS s ON l.Id = s.LocationId
WHERE Province = 'Sofia'
GROUP BY l.Province, l.Municipality, l.[Name]
ORDER BY COUNT(*) DESC, l.[Name]

GO

-- Problem 08
SELECT	
	s.[Name] AS Site
	,l.[Name] AS Location
	,l.Municipality
	,l.Province
	,s.Establishment
FROM Sites AS s 
JOIN Locations AS l ON s.LocationId = l.Id
WHERE l.[Name] LIKE '[^B,^M,^D]%' 
AND s.Establishment LIKE '%BC'
ORDER BY s.[Name] ASC

GO

-- Problem 09
SELECT 
	t.[Name]
	,t.Age
	,t.PhoneNumber
	,t.Nationality
	,CASE 
		WHEN bp.[Name] IS NULL THEN '(no bonus prize)'
		ELSE bp.[Name] END AS Reward
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tbp ON t.Id = tbp.TouristId
LEFT JOIN BonusPrizes AS bp ON bp.Id = tbp.BonusPrizeId
ORDER BY t.[Name]

GO

-- Problem 10
SELECT 
	SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]) + 1, LEN(t.[Name])) AS LastName
	,t.Nationality
	,t.Age
	,t.PhoneNumber
FROM Tourists AS t 
JOIN SitesTourists AS st ON st.TouristId = t.Id
JOIN Sites AS s ON s.Id = st.SiteId
JOIN Categories AS c ON s.CategoryId = c.Id
WHERE c.[Name] = 'History and archaeology'
GROUP BY t.[Name], t.Nationality, t.Age, t.PhoneNumber
ORDER BY LastName

GO

-- Problem 11
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(50))
RETURNS INT AS
BEGIN
	DECLARE @CountOfTouristsVisited INT

	SET @CountOfTouristsVisited = 
	(
		SELECT COUNT(*)
		FROM Sites AS s 
		JOIN SitesTourists AS st ON st.SiteId = s.Id
		JOIN Tourists AS t ON st.TouristId = t.Id
		WHERE s.[Name] = @Site
	)

	RETURN @CountOfTouristsVisited
END

GO

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')

GO

-- Problem 12
CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
	DECLARE @CountOfTouristsVisited INT

	SET @CountOfTouristsVisited = 
	(
		SELECT COUNT(*)
		FROM Tourists AS t 
		JOIN SitesTourists AS st ON st.TouristId = t.Id
		JOIN Sites AS s ON s.Id = st.SiteId
		WHERE t.[Name] = @TouristName
	)

	IF(@CountOfTouristsVisited >= 100)
		BEGIN 
			UPDATE Tourists
			SET Reward = 'Gold badge'
			WHERE [Name] = @TouristName
		END
	ELSE IF(@CountOfTouristsVisited >= 50)
		BEGIN 
			UPDATE Tourists
			SET Reward = 'Silver badge'
			WHERE [Name] = @TouristName	
		END
	ELSE IF(@CountOfTouristsVisited >= 25)
		BEGIN
			UPDATE Tourists
			SET Reward = 'Bronze badge'
			WHERE [Name] = @TouristName
		END

	SELECT 
		[Name]
		,Reward
	FROM Tourists
	WHERE [Name] = @TouristName
END


EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'







