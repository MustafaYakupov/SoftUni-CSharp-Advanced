CREATE DATABASE Accounting

GO

USE Accounting

GO

-- Problem 01 DDL
CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY
	,StreetName NVARCHAR(20) NOT NULL
	,StreetNumber INT 
	,PostCode INT NOT NULL
	,City VARCHAR(25) NOT NULL
	,CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Vendors
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(25) NOT NULL
	,NumberVAT NVARCHAR(15) NOT NULL
	,AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(25) NOT NULL
	,NumberVAT NVARCHAR(15) NOT NULL
	,AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(35) NOT NULL
	,Price DECIMAL(18,2) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,VendorId INT FOREIGN KEY REFERENCES Vendors(Id) NOT NULL
)

CREATE TABLE Invoices
(
	Id INT PRIMARY KEY IDENTITY
	,Number INT NOT NULL
	,IssueDate DateTime2 NOT NULL
	,DueDate DateTime2 NOT NULL
	,Amount DECIMAL(18,2) NOT NULL
	,Currency VARCHAR(5) NOT NULL
	,ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
)

CREATE TABLE ProductsClients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id)
	,ClientId INT FOREIGN KEY REFERENCES Clients(Id)
	,PRIMARY KEY(ProductId, ClientId)
)

GO

-- Problem 02
INSERT INTO Products([Name], Price, CategoryId, VendorId)
VALUES 
	('SCANIA Oil Filter XD01', 78.69, 1, 1)
	,('MAN Air Filter XD01', 97.38, 1, 5)
	,('DAF Light Bulb 05FG87', 55.00, 2, 13)
	,('ADR Shoes 47-47.5', 49.85, 3, 5)
	,('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices (Number, IssueDate, DueDate, Amount, Currency, ClientId) 
VALUES 
(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3)
,(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13)
,(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)

GO

-- Problem 03
UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE IssueDate LIKE ('2022-11-%') 

UPDATE Clients 
SET AddressId = 3
WHERE [Name] LIKE ('%CO%') 

GO

-- Problem 04
--SELECT * 
DELETE
FROM Invoices
WHERE ClientId = 11

--SELECT *
DELETE
FROM ProductsClients
WHERE ClientId = 11

--SELECT * 
DELETE
FROM Clients
WHERE NumberVAT LIKE 'IT%'

GO

-- Problem 05
SELECT 
	Number
	,Currency
FROM Invoices
ORDER BY Amount DESC, DueDate

GO

-- Problem 06
SELECT 
	p.Id
	,p.[Name]
	,p.Price
	,c.[Name] AS CategoryName
FROM Products AS p
JOIN Categories AS c ON c.Id = p.CategoryId
WHERE c.[Name] LIKE '%ADR%' OR c.[Name] LIKE 'Others'
ORDER BY p.Price DESC

GO

-- Problem 07
SELECT 
	c.Id
	,c.[Name] AS Client
	,CONCAT_WS(', ', CONCAT_WS(' ', a.StreetName, a.StreetNumber), a.City, a.PostCode, ctr.[Name]) AS [Address]
FROM Clients AS c
LEFT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
LEFT JOIN Products AS p ON p.Id = pc.ProductId
LEFT JOIN Addresses AS a ON a.Id = c.AddressId
LEFT JOIN Countries AS ctr ON ctr.Id = a.CountryId
WHERE pc.ProductId IS NULL
ORDER BY c.[Name]

-- Problem 08
SELECT TOP (7)
	i.Number
	,i.Amount
	,c.[Name] AS Client
FROM Invoices AS i
JOIN Clients AS c ON i.ClientId = c.Id
WHERE YEAR(i.IssueDate) < 2023 AND i.Currency = 'EUR'
OR i.Amount > 500.00 AND c.NumberVAT LIKE 'DE%'
ORDER BY i.Number, i.Amount DESC

GO

-- Problem 09
SELECT 
	c.[Name] AS Client
	,MAX(p.Price)
	,c.NumberVAT AS [VAT Number]
FROM Clients AS c 
JOIN ProductsClients AS pc ON pc.ClientId = c.Id
JOIN Products AS p ON pc.ProductId = p.Id
WHERE c.[Name] NOT LIKE '%KG'
GROUP BY c.[Name], c.NumberVAT
ORDER BY MAX(p.Price) DESC

-- Problem 10
SELECT 
	c.[Name]
	,FLOOR(AVG(p.Price)) AS [Average Price]
FROM Clients AS c 
LEFT JOIN ProductsClients AS pc ON pc.ClientId = c.Id
LEFT JOIN Products AS p ON pc.ProductId = p.Id
LEFT JOIN Vendors AS v ON v.Id = p.VendorId
WHERE pc.ProductId IS NOT NULL AND v.NumberVAT LIKE '%FR%'
GROUP BY c.[Name]
ORDER BY FLOOR(AVG(p.Price)), c.[Name] DESC

GO

-- Problem 11
CREATE FUNCTION udf_ProductWithClients(@name VARCHAR(50))
RETURNS INT AS
BEGIN
	DECLARE @TotalAmountOfClients INT;

	SET @TotalAmountOfClients = 
	(
		SELECT COUNT(*)
		FROM Clients AS c 
		JOIN ProductsClients AS pc ON pc.ClientId = c.Id
		JOIN Products AS p ON pc.ProductId = p.Id 
		WHERE p.[Name] = @name
	)

	RETURN @TotalAmountOfClients;
END

GO

SELECT dbo.udf_ProductWithClients('DAF FILTER HU12103X')

GO

-- Problem 12
CREATE PROC usp_SearchByCountry(@country VARCHAR(50)) 
AS
BEGIN
	SELECT 
		v.[Name] Vendor
		,v.NumberVAT AS VAT
		,CONCAT_WS(' ', a.StreetName, a.StreetNumber) AS [Street Info]
		,CONCAT_WS(' ', a.City, a.PostCode) AS [City Info]
	FROM Vendors AS v
	JOIN Addresses AS a ON a.Id = v.AddressId
	JOIN Countries AS c ON a.CountryId = c.Id
	WHERE c.[Name] = @country
	ORDER BY v.[Name], a.City DESC
END

EXEC usp_SearchByCountry 'France'





