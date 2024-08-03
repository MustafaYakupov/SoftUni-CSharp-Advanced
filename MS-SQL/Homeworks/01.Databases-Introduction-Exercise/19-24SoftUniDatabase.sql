CREATE DATABASE [SoftUni]

GO

USE SoftUni

-- Create Towns table
CREATE TABLE Towns (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(100) NOT NULL
);

INSERT INTO Towns ([Name])
	VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas');

-- Create Addresses table
CREATE TABLE Addresses (
    Id INT PRIMARY KEY IDENTITY,
    AddressText VARCHAR(255) NOT NULL,
    TownId INT,
    FOREIGN KEY (TownId) REFERENCES Towns(Id)
);

-- Create Departments table
CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(100) NOT NULL
);

INSERT INTO Departments ([Name])
	VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance');


-- Create Employees table
CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50),
    LastName VARCHAR(50) NOT NULL,
    JobTitle VARCHAR(100) NOT NULL,
    DepartmentId INT,
    HireDate DATE,
    Salary DECIMAL(10, 2) NOT NULL,
    AddressId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

INSERT INTO Employees ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
	VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);

USE SoftUni

SELECT * FROM [Towns]
ORDER BY [Name];
SELECT * FROM [Departments]
ORDER BY [Name];
SELECT * FROM [Employees]
ORDER BY [Salary] DESC;

SELECT [Name] from [Towns]
ORDER BY [Name];
SELECT [Name] from [Departments]
ORDER BY [Name];
SELECT [FirstName], [LastName], [JobTitle], [Salary] from [Employees]
ORDER BY [Salary] DESC;

USE SoftUni

UPDATE [Employees]
SET [Salary] = [Salary] * 1.1;

SELECT [Salary] FROM [Employees];

GO

USE Hotel

GO

UPDATE Payments
SET TaxRate = TaxRate * 0.97

SELECT 
	TaxRate
FROM Payments

GO

DROP TABLE  Occupancies

