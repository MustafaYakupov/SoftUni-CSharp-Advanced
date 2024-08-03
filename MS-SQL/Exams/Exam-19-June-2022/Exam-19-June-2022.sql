CREATE DATABASE Zoo

GO

USE Zoo

GO

-- Problem 01 DDL
CREATE TABLE Owners
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,PhoneNumber VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
	Id INT PRIMARY KEY IDENTITY
	,AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
	Id INT PRIMARY KEY IDENTITY
	,AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id)  NOT NULL
)

CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) NOT NULL
	,BirthDate DATE NOT NULL
	,OwnerId INT FOREIGN KEY REFERENCES Owners(Id)
	,AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages
(
	CageId INT FOREIGN KEY REFERENCES Cages(Id)
	,AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
	,PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
	Id INT PRIMARY KEY IDENTITY
	,DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,PhoneNumber VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50) 
	,AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
	,DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)

-- Problem 02 DML
INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
VALUES 
	('Giraffe', '2018-09-21', 21, 1)
	,('Harpy Eagle', '2015-04-17', 15, 3)
	,('Hamadryas Baboon', '2017-11-02', NULL, 1)
	,('Tuatara', '2021-06-30', 2, 4)

INSERT INTO Volunteers([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
VALUES
	('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1)
	,('Dimitur Stoev', '0877564223', NULL, 42, 4)
	,('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7)
	,('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8)
	,('Boryana Mileva', '0888112233', NULL, 31, 5)

-- Problem 03
UPDATE Animals
SET OwnerId = 
(
	SELECT Id
	FROM Owners
	WHERE [Name] = 'Kaloqn Stoqnov'
)
WHERE OwnerId IS NULL

-- Problem 04
SELECT * 
FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

SELECT *
FROM Volunteers
WHERE DepartmentId = 2

-- First we need to realease the volunteers from the deteleted department
DELETE 
FROM Volunteers
WHERE DepartmentId = 
(
	SELECT Id 
	FROM VolunteersDepartments
	WHERE DepartmentName = 'Education program assistant'
)

DELETE 
FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

-- Problem 05
SELECT
	[Name]
	,PhoneNumber
	,[Address]
	,AnimalId
	,DepartmentId
FROM Volunteers
ORDER BY [Name], AnimalId, DepartmentId

-- Problem 06
SELECT 
	a.[Name]
	,T.AnimalType
	,FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals AS a
JOIN AnimalTypes AS T ON T.Id = a.AnimalTypeId 
ORDER BY a.[Name]

-- Problem 07
SELECT TOP(5)
	o.[Name] AS [Owner]
	,COUNT(a.Id) AS CountOfAnimals
FROM Owners AS o
LEFT JOIN Animals AS a ON o.Id = a.OwnerId
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC

-- Problem 08
SELECT 
	CONCAT_WS('-', o.[Name], a.[Name]) AS OwnersAnimals
	,o.PhoneNumber
	,ac.CageId
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
JOIN AnimalTypes AS t ON a.AnimalTypeId = t.Id
JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
WHERE t.AnimalType = 'Mammals'
ORDER BY o.[Name], a.[Name] DESC

-- Problem 09
SELECT 
	[Name]
	,PhoneNumber
	,LTRIM(REPLACE(REPLACE([Address], 'Sofia', ''), ',', ''))
FROM Volunteers
WHERE DepartmentId = 2
AND [Address] LIKE '%Sofia%'
ORDER BY [Name]

-- Problem 10
SELECT 
	a.[Name]
	,YEAR(a.BirthDate) AS BirthYear
	,t.AnimalType
FROM Animals AS a
JOIN AnimalTypes AS t ON t.Id = a.AnimalTypeId
WHERE OwnerId IS NULL 
AND YEAR(BirthDate) > 2017
AND t.AnimalType <> 'Birds'
ORDER BY a.[Name]

-- Problem 11 - FUNCTION
CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT AS
BEGIN
	DECLARE @departmentId INT
	SET @departmentId = 
	(
		SELECT 
			Id
		FROM VolunteersDepartments
		WHERE DepartmentName = @VolunteersDepartment
	)

	DECLARE @departmentVolunteersCount INT
	SET @departmentVolunteersCount = 
	(
		SELECT COUNT(*) 
		FROM Volunteers
		WHERE DepartmentId = @departmentId
	)

	RETURN @departmentVolunteersCount
END

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')

-- Problem 12 - Procedure
CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT 
		a.[Name]
		,ISNULL(o.[Name], 'For adoption') AS OwnersName
	FROM Animals AS a 
	LEFT JOIN Owners AS o ON a.OwnerId = o.Id
	WHERE a.[Name] = @AnimalName
END

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'