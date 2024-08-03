use SoftUni

GO

-- Problem 01

SELECT 
	FirstName
	,LastName
	FROM Employees
	WHERE FirstName LIKE 'Sa%'

-- Problem 02
SELECT	
	FirstName
	,LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

-- Problem 03
SELECT FirstName
	FROM Employees
	WHERE DepartmentID IN (3, 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

-- Problem 04
SELECT	
	FirstName
	,LastName
	FROM Employees
	WHERE CHARINDEX('engineer', JobTitle) = 0

-- Problem 05
SELECT
	[Name]
	FROM Towns
	--WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
	WHERE LEN([Name]) IN (5, 6)
	ORDER BY [Name]

-- Problem 06
-- Method 1
SELECT * 
	FROM Towns
	WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
	ORDER BY [Name]

-- Method 2
SELECT * 
	FROM Towns
	WHERE [Name] LIKE '[MKBE]%'
	ORDER BY [Name]

-- Problem 07
SELECT * 
	FROM Towns
	WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
	ORDER BY [Name]

GO

-- Problem 08
CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT
	FirstName
	,LastName
	FROM Employees
	WHERE YEAR(HireDate) > 2000

GO

-- Problem 09
SELECT
	FirstName
	,LastName
	FROM Employees
	WHERE LEN(LastName) = 5

-- Problem 10
SELECT 
	EmployeeID
	,FirstName
	,LastName
	,Salary
	,DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

-- Problem 11*
SELECT *
	FROM (SELECT 
		EmployeeID
		,FirstName
		,LastName
		,Salary
		,DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
		FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000
	) AS RankingSubquery
WHERE [Rank] = 2
ORDER BY Salary DESC

GO

USE [Geography]

GO
-- Problem 12
-- Method 1
SELECT 
	CountryName AS [Country Name]
	,ISOCode AS [ISO Code]
	FROM  Countries
	WHERE LOWER(CountryName) LIKE '%a%a%a%'
	ORDER BY IsoCode 

-- Method 2
SELECT 
	CountryName AS [Country Name]
	,ISOCode AS [ISO Code]
	FROM  Countries
	WHERE LEN(CountryName) - LEN(REPLACE(LOWER(CountryName), 'a', '')) >= 3
	ORDER BY IsoCode 

-- Problem 13
SELECT 
	p.PeakName
	,r.RiverName
	,LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) - 1), r.RiverName)) AS Mix
	FROM Peaks AS p
	,Rivers as r
WHERE RIGHT(LOWER(p.PeakName), 1) = LEFT(LOWER(r.RiverName), 1)
ORDER BY Mix

GO

USE Diablo

GO
-- Problem 14
SELECT TOP (50) [Name], cast([Start] as date)
	FROM Games
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], [Name]

-- Problem 15
SELECT 
	Username
	,SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], Username

-- Problem 16
SELECT 
	Username
	,IpAddress
	FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

-- Problem 17
SELECT 
	[Name] AS Game
	,CASE 
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day]
	,CASE 
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 3 THEN 'Long'
		ELSE 'Extra Long'
	END AS Duration
	FROM Games
	AS g
	ORDER BY Game, Duration