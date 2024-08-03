-- Dynamic SQL - CAN'T BE USED IN FUNCTION
DECLARE @salary INT = 10000;
DECLARE @statement NVARCHAR(1000);
BEGIN
	SET @salary = 10000;
	SET @statement = CONCAT('SELECT * FROM Employees WHERE Salary > ', @salary);
	EXECUTE sp_executesql @statement;
END; 


-- Function
CREATE FUNCTION udf_CalculateProjectPeriod(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT AS 
BEGIN
	 IF @EndDate IS NULL 
	 BEGIN
		SET @EndDate = GETDATE();
	 END;

	 RETURN DATEDIFF(DAY, @StartDate, @EndDate);
END;

SELECT *, dbo.udf_CalculateProjectPeriod(StartDate, EndDate) AS Duration 
FROM Projects

-- Salary level function
CREATE FUNCTION udf_GetSalary_Level(@Salary MONEY)
RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @level VARCHAR(10) = 'Average';

	IF @Salary < 30000
	BEGIN
		SET @level = 'Low';
	END;
	ELSE IF @Salary > 50000
	BEGIN
		SET @level = 'High';
	END;

	RETURN @level;
END;

SELECT *, dbo.udf_GetSalary_Level(Salary) AS SalaryLevel FROM Employees