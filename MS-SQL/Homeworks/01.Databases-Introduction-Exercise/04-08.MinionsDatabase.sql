CREATE DATABASE [Minions]

GO

USE [Minions]

GO

CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL,
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(70) NOT NULL,
)

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

GO

INSERT INTO [Towns] ([Id], [Name])
	VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId])
	VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

UPDATE [Minions]
SET [TownId] = 3
WHERE [Name] = 'Bob'

UPDATE [Minions]
SET [TownId] = 2
WHERE [Name] = 'Steward'

GO

SELECT * 
	FROM [Towns]
SELECT * 
	FROM [Minions]

GO

TRUNCATE TABLE [Minions]

DROP TABLE Minions
DROP TABLE Towns
DROP TABLE [Users]

GO

CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(200)  NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] ([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
('Ivan', 1.88, 100.50, 'm', '1999-12-20'),
('Pesho', 1.88, 100.50, 'm', '1999-12-20'),
('Gosho', 1.88, 100.50, 'm', '1999-12-20'),
('Stamat', 1.88, 100.50, 'm', '1999-12-20'),
('Nino', 1.88, 100.50, 'm', '1999-12-20')

CREATE TABLE [Users] (
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT,
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
	VALUES
('Ivan', '123433', 5, '2020-12-20', 0),
('Pesho', '123433', 5, '2020-12-20', 0),
('Gosho', '123334', 5, '2020-12-20', 0),
('Stamat', '123334', 5, '2020-12-20', 0),
('Nino', '123334', 5, '2020-12-20', 0)

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC0710E7FE78;

ALTER TABLE [Users]
ADD CONSTRAINT PK_Users
PRIMARY KEY([Id], [Username])

ALTER TABLE [Users]
	ADD CONSTRAINT CHK_PasswordLength
	CHECK (LEN([Password]) > 5);

ALTER TABLE [Users]
	ADD CONSTRAINT DF_DefaultValueForLastLogin
	DEFAULT GETDATE() FOR [LastLoginTime];

	ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC0711B61CBA;

ALTER TABLE [Users]
ADD CONSTRAINT PK_Id
PRIMARY KEY([Id]);

ALTER TABLE [Users]
	ADD CONSTRAINT UQ_Username UNIQUE ([Username]),
	CONSTRAINT MinLength CHECK (LEN(Username) >= 3);