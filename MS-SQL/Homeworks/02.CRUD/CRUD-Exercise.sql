USE Softuni

GO

SELECT FirstName, MiddleName, LastName 
  FROM Employees

SELECT * 
  FROM Employees

 SELECT 
	Name
 FROM Departments

 SELECT 
	FirstName
	,LastName
	,Salary
 FROM Employees

  SELECT 
	FirstName
	,MiddleName
	,LastName
 FROM Employees

-- Problem 06
SELECT CONCAT(FirstName, '.', LastName, '@', 'softuni.bg')
    AS [Full Email Address]
  FROM Employees

-- PRoblem 07
  SELECT  DISTINCT Salary
		      FROM Employees

-- Problem 08
SELECT * FROM Employees
		WHERE JobTitle =  'Sales Representative'

-- Problem 09
SELECT FirstName, LastName, JobTitle FROM Employees
 WHERE Salary BETWEEN 20000 AND 30000

-- Problem 10
SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) 
  FROM Employees
 WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600

 -- Problem 11
 SELECT FirstName, LastName
   FROM Employees
  WHERE ManagerID IS NULL

  -- Problem 12
  SELECT FirstName, LastName, Salary
    FROM Employees
   WHERE Salary >= 50000 
   ORDER BY Salary DESC

-- Problem 13
SELECT TOP (5) FirstName, LastName 
          FROM Employees
      ORDER BY Salary DESC
	  
-- Problem 14
SELECT FirstName, LastName
  FROM Employees
 WHERE DepartmentID <> 4

 -- Problem 15
 SELECT * 
 FROM Employees
 ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC

 -- Probloem 16
 GO

 CREATE VIEW V_EmployeesSalaries AS
      SELECT FirstName, LastName, Salary
        FROM Employees;

GO

-- Problem 17
GO

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT_WS(' ', FirstName, ISNULL(MiddleName, ''), LastName) AS [Full Name], JobTitle
FROM Employees

GO

-- Problem 18
SELECT DISTINCT JobTitle
FROM Employees

-- Problem 19
SELECT TOP (10) * 
 FROM Projects
WHERE StartDate IS NOT NULL
ORDER BY StartDate, [Name]

-- Problem 20
SELECT TOP (7) FirstName, LastName, HireDate
FROM Employees
ORDER BY HireDate DESC

-- Problem 21
-- Helper queries
SELECT DepartmentID
  FROM Departments
 WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')

 -- Main query
UPDATE Employees 
   SET Salary *= 1.12
 WHERE DepartmentID IN (1, 2, 4, 11)

 SELECT Salary
   FROM Employees

-- Part II – Queries for Geography Database
USE Geography

-- Problem 22
  SELECT PeakName
    FROM Peaks
ORDER BY PeakName

-- Problem 23
SELECT TOP (30) CountryName, [Population]
FROM Countries
WHERE ContinentCode IN ('EU')
ORDER BY [Population] DESC, CountryName ASC

-- Problem 24
SELECT CountryName, 
       CountryCode,
       CASE CurrencyCode
       WHEN 'EUR' THEN 'Euro'
       ELSE 'Not Euro'
     END AS Currency
       FROM Countries
   ORDER BY CountryName

-- Part III – Queries for Diablo Database

USE Diablo

-- Problem 25
  SELECT [Name]
    FROM Characters
ORDER BY [Name]

