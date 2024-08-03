SELECT TOP 50
	e.FirstName
	,e.LastName
	,t.[Name] AS Town
	,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID

GO

SELECT 
	e.EmployeeID 
	,e.FirstName
	,e.LastName
	,d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d on e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

GO

SELECT 
	e.FirstName
	,e.LastName
	,e.HireDate
	,d.[Name] AS DepName
FROM Employees AS e 
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE 
	e.HireDate > '1999-1-1'
	AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

GO

SELECT 
	e.EmployeeID
	,CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName
	,CONCAT_WS(' ', m.FirstName, m.LastName) AS ManagerName
	,d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY EmployeeID

GO

-- Subqueries
SELECT 
	MIN(avs.AvgSalary) 
FROM
(
	SELECT 
		AVG(Salary) AS AvgSalary
	FROM Employees
	GROUP BY DepartmentID
) AS avs

-- Common Table Expressions CTE - Named Subqueries
WITH AvgSalaryByDep (DepartmentId, AvgSalary)
AS
(
	SELECT 
		DepartmentID
		,AVG(Salary)
	FROM Employees
	GROUP BY DepartmentID
)

SELECT MIN(AvgSalary) 
FROM AvgSalaryByDep



