CREATE DATABASE [Hotel]

GO

USE [Hotel];

-- Create Employees table
CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Title VARCHAR(100),
    Notes VARCHAR(255)
);

-- Populate Employees table
INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES
    (1, 'John', 'Doe', 'Front Desk Clerk', 'Excellent customer service skills'),
    (2, 'Jane', 'Smith', 'Manager', '10 years experience in hospitality industry'),
    (3, 'Michael', 'Johnson', 'Housekeeping Supervisor', 'Attention to detail');

-- Create Customers table
CREATE TABLE Customers (
    AccountNumber INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(20),
    EmergencyName VARCHAR(100),
    EmergencyNumber VARCHAR(20),
    Notes VARCHAR(255)
);

-- Populate Customers table
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
    (1001, 'Alice', 'Johnson', '555-1234', 'Bob Johnson', '555-5678', 'Frequent guest'),
    (1002, 'Bob', 'Smith', '555-5678', 'Carol Smith', '555-9876', 'VIP member'),
    (1003, 'Carol', 'Williams', '555-9876', 'David Williams', '555-4321', 'Corporate account');

-- Create RoomStatus table
CREATE TABLE RoomStatus (
    RoomStatus VARCHAR(50) PRIMARY KEY,
    Notes VARCHAR(255)
);

-- Populate RoomStatus table
INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES
    ('Occupied', 'Room is currently occupied by a guest'),
    ('Available', 'Room is available for booking'),
    ('Reserved', 'Room is reserved for a future booking');

-- Create RoomTypes table
CREATE TABLE RoomTypes (
    RoomType VARCHAR(50) PRIMARY KEY,
    Notes VARCHAR(255)
);

-- Populate RoomTypes table
INSERT INTO RoomTypes (RoomType, Notes)
VALUES
    ('Standard', 'Basic room with standard amenities'),
    ('Deluxe', 'Larger room with upgraded amenities'),
    ('Suite', 'Luxurious suite with separate living area');

-- Create BedTypes table
CREATE TABLE BedTypes (
    BedType VARCHAR(50) PRIMARY KEY,
    Notes VARCHAR(255)
);

-- Populate BedTypes table
INSERT INTO BedTypes (BedType, Notes)
VALUES
    ('Single', 'One single bed'),
    ('Double', 'One double bed'),
    ('King', 'One king-size bed');

-- Create Rooms table
CREATE TABLE Rooms (
    RoomNumber INT PRIMARY KEY,
    RoomType VARCHAR(50),
    BedType VARCHAR(50),
    Rate DECIMAL(10, 2),
    RoomStatus VARCHAR(50),
    Notes VARCHAR(255),
    FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
    FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
    FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus)
);

-- Populate Rooms table
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
    (101, 'Standard', 'Single', 100.00, 'Available', 'Room with city view'),
    (102, 'Deluxe', 'Double', 150.00, 'Available', 'Room with ocean view'),
    (103, 'Suite', 'King', 250.00, 'Available', 'Luxurious suite with balcony');

-- Create Payments table
CREATE TABLE Payments (
    Id INT PRIMARY KEY,
    EmployeeId INT,
    PaymentDate DATE,
    AccountNumber INT,
    FirstDateOccupied DATE,
    LastDateOccupied DATE,
    TotalDays INT,
    AmountCharged DECIMAL(10, 2),
    TaxRate DECIMAL(5, 2),
    TaxAmount DECIMAL(10, 2),
    PaymentTotal DECIMAL(10, 2),
    Notes VARCHAR(255),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber)
);

-- Populate Payments table
INSERT INTO Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
    (1, 1, '2022-04-01', 1001, '2022-03-25', '2022-03-28', 3, 300.00, 0.10, 30.00, 330.00, 'Payment for Room 101'),
    (2, 2, '2022-04-01', 1001, '2022-03-25', '2022-03-28', 3, 300.00, 0.10, 30.00, 330.00, 'Payment for Room 101'),
    (3, 3, '2022-04-01', 1001, '2022-03-25', '2022-03-28', 3, 300.00, 0.10, 30.00, 330.00, 'Payment for Room 101');

CREATE TABLE Occupancies  (
    Id INT PRIMARY KEY,
    EmployeeId INT,
    PaymentDate DATE,
    DateOccupied DATETIME2,
    AccountNumber INT,
    RoomNumber INT,
    RateApplied DECIMAL(10, 2),
    PhoneCharge INT,
    Notes NVARCHAR(100),
	FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber)
);

INSERT INTO Occupancies (Id, EmployeeId, PaymentDate, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
    (1, 1, '2022-04-01', '2022-03-25', '11122', 3, 300.00, 70, 'Booking for Room 101'),
    (2, 2, '2022-04-01', '2022-03-25', '22333', 2, 300.00, 50, 'Booking for Room 102'),
    (3, 3, '2022-04-01', '2022-03-25', '45565', 1, 300.00, 23, 'Booking for Room 103');

USE Hotel;

UPDATE Payments
SET TaxRate = TaxRate * 0.97;

SELECT TaxRate FROM Payments;

DELETE FROM Occupancies;