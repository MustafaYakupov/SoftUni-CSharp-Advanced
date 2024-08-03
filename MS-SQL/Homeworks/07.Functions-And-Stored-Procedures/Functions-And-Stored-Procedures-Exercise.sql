USE SoftUni

GO

-- Problem 01
-- Judge does not like CREATE OR ALTER
CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS 
BEGIN
	SELECT
		FirstName
		,LastName
	FROM Employees
	WHERE Salary > 35000
END;

EXEC dbo.usp_GetEmployeesSalaryAbove35000 

GO

-- Problem 02
CREATE PROC usp_GetEmployeesSalaryAboveNumber @minSalary DECIMAL(18, 4)
AS 
BEGIN
	SELECT 
		FirstName
		,LastName
	FROM Employees
	WHERE Salary >= @minSalary
END;

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100

GO
-- Problem 03
CREATE PROC usp_GetTownsStartingWith  @input NVARCHAR(50)
AS
BEGIN
	SELECT	
		[Name] AS Town
	FROM Towns
	WHERE [Name] LIKE CONCAT(@input, '%')
END

EXEC dbo.usp_GetTownsStartingWith 'b'

GO

-- Problem 04
CREATE PROC usp_GetEmployeesFromTown  @townName NVARCHAR(100)
AS 
BEGIN
	SELECT 
		FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM Employees as e 
	JOIN Addresses as a ON e.AddressID = a.AddressID
	JOIN Towns as t ON a.TownID = t.TownID
	WHERE t.[Name] = @townName
END

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'

GO

-- Problem 05
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10) 
AS
BEGIN
	DECLARE @level VARCHAR(10) = '';

	IF @salary < 30000
	BEGIN
		SET @level = 'Low'
	END
	ELSE IF @salary > 50000
	BEGIN	
		SET @level = 'High'
	END
	ELSE 
	BEGIN
		SET @level = 'Average'
	END

	RETURN @level
END

SELECT *, dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel FROM Employees

GO

-- Problem 06
CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS 
BEGIN
	SELECT 
	FirstName AS [First Name]
	,LastName AS [Last Name]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END	

GO

-- Problem 07
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @wordIndex INT = 1
	WHILE (@wordIndex <= LEN(@word))
	BEGIN
		DECLARE @currentCharacter CHAR = SUBSTRING(@word, @wordIndex, 1)

		IF CHARINDEX(@currentCharacter, @setOfLetters) = 0
		BEGIN
			RETURN 0
		END	

		SET @wordIndex += 1
	END

	RETURN 1;
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

GO

USE Bank

GO

-- Problem 09
CREATE PROCEDURE usp_GetHoldersFullName 
AS
BEGIN
	SELECT 
		CONCAT_WS(' ', FirstName, LastName) AS [Full Name]
	FROM AccountHolders
END

EXEC dbo.usp_GetHoldersFullName

GO

-- Problem 10
CREATE PROC usp_GetHoldersWithBalanceHigherThan  @number INT
AS
BEGIN
	SELECT
		FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.Id
	WHERE Balance > @number
	ORDER BY ah.FirstName, ah.LastName
END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 3200

GO
-- Problem 11
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(15,4),
@YearlyInterestRate FLOAT,
@NumberOfYears INT )
RETURNS DECIMAL(15,4)
BEGIN
    DECLARE @FutureValue DECIMAL(15,4);

    SET @FutureValue = @Sum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
    
    RETURN @FutureValue
END

Go

-- Problem 12
CREATE PROC usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT) 
AS
BEGIN
SELECT a.Id AS [Account Id],
	   ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name],
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a ON ah.Id = a.Id
 WHERE a.Id = @AccountId
 END