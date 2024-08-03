CREATE DATABASE RailwaysDb 

GO

USE RailwaysDb 

Go

-- Problem 01 DDL
CREATE TABLE Passengers 
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Trains
(
	Id INT PRIMARY KEY IDENTITY
	,HourOfDeparture VARCHAR(5) NOT NULL
	,HourOfArrival VARCHAR(5) NOT NULL
	,DepartureTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
	,ArrivalTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE TrainsRailwayStations
(
	TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
	,RailwayStationId INT FOREIGN KEY REFERENCES RailwayStations(Id) NOT NULL
	,PRIMARY KEY(TrainId, RailwayStationId)
)

CREATE TABLE MaintenanceRecords
(
	Id INT PRIMARY KEY IDENTITY
	,DateOfMaintenance Date NOT NULL
	,Details VARCHAR(2000) NOT NULL
	,TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY
	,Price Decimal(10, 2)  NOT NULL
	,DateOfDeparture Date NOT NULL
	,DateOfArrival Date NOT NULL
	,TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
	,PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

GO

-- Problem 02
INSERT INTO Trains(HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES 
	('07:00', '19:00', 1, 3)
	,('08:30', '20:30', 5, 6)
	,('09:00', '21:00', 4, 8)
	,('06:45', '03:55', 27, 7)
	,('10:15', '12:15', 15, 5)


INSERT INTO Tickets(Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES 
	(90.00, '2023-12-01', '2023-12-01', 36, 1)
	,(115.00,'2023-08-02', '2023-08-02', 37, 2)
	,(160.00,'2023-08-03', '2023-08-03', 38, 3)
	,(255.00,'2023-09-01', '2023-09-02', 39, 21)
	,(95.00,'2023-09-02', '2023-09-03', 40, 22)
	 
INSERT INTO TrainsRailwayStations(TrainId, RailwayStationId)
VALUES 
	(36, 1), (36, 4), (36, 31), (36, 57), (36, 7)
	,(37, 13), (37, 54), (37, 60), (37, 16)
	,(38, 10), (38, 50), (38, 52), (38, 22)
	,(39, 68), (39, 3), (39, 31), (39, 19)
	,(40, 41), (40, 7), (40, 52), (40, 13)

GO

-- Problem 03
UPDATE Tickets 
SET DateOfDeparture =  DATEADD(day, 7, DateOfDeparture), 
DateOfArrival =  DATEADD(day, 7, DateOfArrival)
WHERE DateOfDeparture > '2023-10-31'

UPDATE Tickets
SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE DateOfDeparture > '2023-10-31';

GO

-- Problem 04
DELETE
FROM TrainsRailwayStations
WHERE TrainId = 7

DELETE
FROM Tickets
WHERE TrainId = 7

DELETE 
FROM MaintenanceRecords
WHERE TrainId = 7

DELETE
FROM Trains
WHERE DepartureTownId = 3

GO

-- Problem 05
SELECT 
	DateOfDeparture
	,Price AS TicketPrice
FROM Tickets
ORDER BY Price, DateOfDeparture DESC

GO

-- Problem 06
SELECT 
	p.[Name] AS PassengerName
	,t.Price AS TicketPrice
	,t.DateOfDeparture AS DateOfDeparture
	,t.TrainId AS TrainID
FROM Tickets AS t
JOIN Passengers AS p on t.PassengerId = p.Id
ORDER BY t.Price DESC, p.[Name]

GO

-- Problem 07
SELECT 
	t.[Name] AS Town
	,rs.[Name] AS RailwayStation
FROM RailwayStations AS rs 
LEFT JOIN Towns AS t on rs.TownId = t.Id
LEFT JOIN TrainsRailwayStations AS trs ON trs.RailwayStationId = rs.Id
LEFT JOIN Trains AS tr ON trs.TrainId = tr.Id
WHERE trs.TrainId IS NULL
ORDER BY Town, RailwayStation

GO

-- Problem 08
SELECT TOP 3
	tr.Id AS TrainId
	,tr.HourOfDeparture
	,t.Price AS TicketPrice
	,twn.[Name] ASDestination
FROM Trains AS tr
JOIN Tickets AS t ON tr.Id = t.TrainId
JOIN Towns AS twn ON tr.ArrivalTownId = twn.Id
WHERE tr.HourOfDeparture BETWEEN '08:00' AND '08:59'
AND t.Price > 50.00
ORDER BY t.Price

GO

-- Problem 09
SELECT 
	twn.[Name] AS TownName
	,COUNT(*) AS PassengersCount
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Trains AS tr ON tr.Id = t.TrainId
JOIN Towns AS twn ON tr.ArrivalTownId = twn.Id
WHERE t.Price > 76.99
GROUP BY twn.[Name]
ORDER BY TownName

GO

-- Problem 10
SELECT 
	tr.Id AS TrainID
	,twn.[Name] AS DepartureTown
	,mr.Details
FROM Trains AS tr
JOIN Towns AS twn ON tr.DepartureTownId = twn.Id
JOIN MaintenanceRecords AS mr ON tr.Id = mr.TrainId
WHERE mr.Details LIKE '%inspection%'
ORDER BY tr.Id

GO

-- Rpoblem 11
CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(50))  
RETURNS INT AS
BEGIN
	DECLARE @TotalNumberOfTrains INT

	SET @TotalNumberOfTrains = 
	(
		SELECT 
			COUNT(DISTINCT tr.Id) 
		FROM Trains AS tr
		JOIN Towns AS twn ON tr.DepartureTownId = twn.Id OR tr.ArrivalTownId = twn.Id
		WHERE twn.Name = @name
	)

	RETURN @TotalNumberOfTrains
END

GO

SELECT dbo.udf_TownsWithTrains('Paris')

GO

-- Problem 12
CREATE PROC usp_SearchByTown(@townName VARCHAR(50)) 
AS
BEGIN
		SELECT 
			p.[Name] AS PassengerName
			,t.DateOfDeparture 
			,tr.HourOfDeparture
		FROM Trains AS tr
		JOIN Tickets AS t ON tr.Id = t.TrainId
		JOIN Passengers AS p ON p.Id = t.PassengerId
		JOIN Towns AS twn ON twn.Id = tr.ArrivalTownId
		WHERE twn.[Name] = @townName
		ORDER BY t.DateOfDeparture DESC, PassengerName
END

GO

EXEC usp_SearchByTown 'Berlin'
