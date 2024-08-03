-- Problem 01
SELECT TOP (5)
	e.EmployeeID
	,e.JobTitle
	,e.AddressID
	,a.AddressText
FROM Employees AS e 
JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY e.AddressID

-- Problem 02
SELECT TOP (50)
	e.FirstName
	,e.LastName
	,t.[Name]
	,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

-- Problem 03
SELECT 
	e.EmployeeID
	,e.FirstName
	,e.LastName
	,d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] IN ('Sales')
ORDER BY e.EmployeeID

-- Problem 04
SELECT TOP (5)
	e.EmployeeID
	,e.FirstName
	,e.Salary
	,d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

-- Problem 05
SELECT TOP (3) 
	e.EmployeeID
	,e.FirstName
FROM Employees AS e 
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID is Null
ORDER BY e.EmployeeID

-- Problem 06
SELECT 
	e.FirstName
	,e.LastName
	,e.HireDate
	,d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND d.[Name] IN ('Sales') OR d.[Name] IN ('Finance')

-- Problem 07
SELECT TOP (5)
	e.EmployeeID
	,e.FirstName
	,p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects as ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- Problem 08
SELECT TOP (5)
	e.EmployeeID
	,e.FirstName
	,CASE 
	WHEN p.StartDate > '2005-01-01' THEN NULL
	ELSE p.[Name]
	END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects as ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

-- Problem 09
SELECT  
	e.EmployeeID
	,e.FirstName
	,m.EmployeeID AS ManagerID
	,m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

-- Problem 10
SELECT TOP (50)
	e.EmployeeID
	,CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName
	,CONCAT_WS(' ', m.FirstName, m.LastName) AS ManagerName
	,d.[Name]
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d on e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- Problem 11
SELECT 
	MIN(avs.AvgSalary) AS MinAverageSalary
FROM 
(
	SELECT 
	AVG(Salary) as AvgSalary
FROM Employees
GROUP BY DepartmentID
) AS avs

GO

USE Geography

GO

-- Problem 12
SELECT 
	mc.CountryCode
	,m.MountainRange
	,p.PeakName
	,p.Elevation
FROM MountainsCountries AS mc
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE mc.CountryCode IN ('BG') AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- Problem 13
SELECT 
	CountryCode
	,COUNT(MountainId) AS MountainRanges
FROM MountainsCountries
WHERE CountryCode IN 
(
	SELECT CountryCode
	FROM Countries
	WHERE CountryName IN ('United States', 'Russia', 'Bulgaria')
)
GROUP BY CountryCode

-- Problem 14
SELECT	TOP (5)
	c.CountryName
	,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr on c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode IN 
(
	SELECT 
		ContinentCode
	FROM Continents
	WHERE ContinentName IN ('Africa')
)
ORDER BY c.CountryName

-- Problem 15
SELECT 
	ContinentCode
	,CurrencyCode
	,CurrencyUsage
FROM 
(
	SELECT * 
		,DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) 
		AS CurrencyRank
	FROM 
	(
		SELECT 
			ContinentCode
			,CurrencyCode
			,COUNT(*) AS CurrencyUsage
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
		HAVING COUNT(*) > 1
	) AS CurrencyUsageSubquery
) AS CurrencyRankingSubquery
WHERE CurrencyRank = 1

-- Problem 16
SELECT 
	COUNT(c.CountryCode) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL

-- Problem 17
SELECT TOP (5)
	c.CountryName
	,MAX(p.Elevation) AS HighestPeakElevation
	,MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName










