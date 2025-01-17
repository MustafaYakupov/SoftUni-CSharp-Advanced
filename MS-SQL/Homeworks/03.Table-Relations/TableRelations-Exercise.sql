CREATE DATABASE [TableRelationsExercise]

GO

USE [TableRelationsExercise]

GO

-- Problem 01
CREATE TABLE [Passports]
(
	[PassportID] INT PRIMARY KEY IDENTITY(101, 1)
	,[PassportNumber] VARCHAR(8)
)

CREATE TABLE [Persons]
(
	[PersonID] INT PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[Salary] DECIMAL(8, 2) NOT NULL
	,[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL -- UNIQUE makes it one-to-one
)

INSERT INTO [Passports]([PassportNumber])
	VALUES
		('N34FG21B'),		
		('K65LO4R7'),		
		('ZE657QP2')


INSERT INTO [Persons]([FirstName], [Salary], [PassportID])
	VALUES
		('Roberto', 43300.00, 102),		
		('Tom', 56100.00, 103),		
		('Yana', 60200.00, 101)

GO 

-- Problem 02

CREATE TABLE [Manufacturers]
(
	[ManufacturerID] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,[EstablishedOn] DATE NOT NULL
)

CREATE TABLE [Models]
(
	[ModelID] INT PRIMARY KEY IDENTITY(101, 1)
	,[Name] VARCHAR(50) NOT NULL
	,[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
)

INSERT INTO Manufacturers([Name], EstablishedOn)
	VALUES
		('BMW', '07/03/1916')
		,('Tesla', '01/01/2003')
		,('Lada', '01/05/1966')

INSERT INTO Models([Name], ManufacturerID)
	VALUES
		('X1', 1)
		,('i6', 1)		
		,('Model S', 2)		
		,('Model X', 2)	
		,('Model 3', 2)		
		,('Nova', 3)

		GO

-- Problem 03
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101, 1)
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
	,ExamID INT FOREIGN KEY REFERENCES Exams(ExamID)
	,PRIMARY KEY(StudentID, ExamID)  -- This makes the table mapping table and Many-to-Many 
)

INSERT INTO Students([Name])
	VALUES
		('Mila')
		,('Toni')
		,('Ron')

INSERT INTO Exams([Name])
	VALUES 
		('SpringMVC')
		,('Neo4j')
		,('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES 
		(1, 101)
		,(1, 102)
		,(2, 101)
		,(3, 103)
		,(2, 102)
		,(2, 103)

GO

-- Problem 04
CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101, 1)
	,[Name] NVARCHAR(50) NOT NULL
	,ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID)
	VALUES
		('John', NULL)
		,('Maya', 106)		
		,('Silvia', 106)	
		,('Ted', 105)		
		,('Mark', 101)	
		,('Greta', 101)

GO

-- Problem 05

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
	,Birthday DATE NOT NULL
	,CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY
	,CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
	,ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID)
	,ItemID INT FOREIGN KEY REFERENCES Items(ItemID)
)

GO

-- Problem 06
CREATE DATABASE [UniveristyDatabase2024]

USE [UniveristyDatabase2024]

GO

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY
	,SubjectName NVARCHAR(100) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY
	,StudentNumber VARCHAR(20) NOT NULL
	,StudentName NVARCHAR(50) NOT NULL
	,MajorID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
	,SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID) NOT NULL
	,PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY
	,PaymentDate DATETIME2 NOT NULL
	,PaymentAmount DECIMAL(8, 2) NOT NULL
	,StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)

GO

-- Problem 09
USE [Geography]

GO

SELECT * 
	FROM Peaks
	AS p
JOIN Mountains
	AS m
	ON p.MountainId = m.Id

