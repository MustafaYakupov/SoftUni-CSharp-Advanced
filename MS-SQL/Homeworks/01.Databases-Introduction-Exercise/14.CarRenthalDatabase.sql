CREATE DATABASE [CarRental]

GO

USE CarRental

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY NOT NULL,
	[CategoryName] NVARCHAR(200) NOT NULL,
	[DailyRate] DECIMAL(4, 2),
	[WeeklyRate] DECIMAL(5, 2),
	[MonthlyRate]  DECIMAL(6, 2),
	[WeekendRate] DECIMAL(5, 2)
);

INSERT INTO [Categories] ([Id], [CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate]) 
	VALUES
	(1, 'SUV', 80.00, 590.00, 1500.00, 300.00),	
	(2, 'Sedan', 40.00, 390.00, 1000.00, 200.00),	
	(3, 'Coupe', 90.00, 690.00, 1800.00, 500.00);

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY NOT NULL,
	[PlateNumber] NVARCHAR(200) NOT NULL,
	[Manufacturer] NVARCHAR(200) NOT NULL,
	[Model] NVARCHAR(200) NOT NULL,
	[CarYear] INT,
	[CategoryId] INT,
	[Doors] INT,
	[Picture] VARBINARY(MAX),
	[Condition] NVARCHAR(50) NOT NULL,
	[Available] BIT NOT NULL,
	FOREIGN KEY ([CategoryId]) REFERENCES [Categories](Id)
)

INSERT INTO [Cars] ([Id], [PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Condition], [Available]) 
	VALUES
	(1, 'E9376MC', 'BMW', '328XI', 2008, 3, 2, 'Perfect', 1),	
	(2, 'E6876HK', 'Mercedes', 'E240', 2002, 2, 4, 'Perfect', 1),	
	(3, 'E1821HH', 'Mercedes', 'ML320', 2001, 1, 5, 'Perfect', 1);

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY NOT NULL,
	[FirstName] NVARCHAR(200) NOT NULL,
	[LastName] NVARCHAR(200) NOT NULL,
	[Title] NVARCHAR(5),
	[Notes]  NVARCHAR(300)
);

INSERT INTO [Employees] ([Id], [FirstName], [LastName], [Title], [Notes]) 
	VALUES
	(1, 'Ivan', 'Ivanov', 'Mr', 'Note info'),	
	(2, 'Gosho', 'Teneev', 'Mr', 'Note info'),	
	(3, 'Pesho', 'Shopov', 'Mr', 'Note info');

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY NOT NULL,
	[DriverLicenceNumber] NVARCHAR(20) NOT NULL,
	[FullName] NVARCHAR(300) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	[City]  NVARCHAR(100),
	[ZIPCode]  NVARCHAR(15),
	[Notes]  NVARCHAR(300),
);

INSERT INTO [Customers] ([Id], [DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes]) 
	VALUES
	(1, '881135254', 'Ivan Totev', 'Cherni vrah', 'Sofia', '2944', 'Extra info'),	
	(2, '881177254', 'Gosho Totev', 'Studentski grad', 'Sofia', '6954', 'Extra info'),	
	(3, '881199254', 'Pesho Totev', 'Dragalevtsi', 'Sofia', '1852', 'Extra info');	

CREATE TABLE [RentalOrders] (
    [Id] INT PRIMARY KEY,
    [EmployeeId] INT,
    [CustomerId] INT,
    [CarId] INT,
    [TankLevel] DECIMAL(5, 2),
    [KilometrageStart] INT,
    [KilometrageEnd] INT,
    [TotalKilometrage] INT,
    [StartDate] DATE,
    [EndDate] DATE,
    [TotalDays] INT,
    [RateApplied] DECIMAL(10, 2),
    [TaxRate] DECIMAL(5, 2),
    [OrderStatus] VARCHAR(50),
    [Notes] VARCHAR(255),
    FOREIGN KEY ([EmployeeId]) REFERENCES [Employees](Id),
    FOREIGN KEY ([CustomerId]) REFERENCES [Customers](Id),
    FOREIGN KEY ([CarId]) REFERENCES [Cars](Id)
);

INSERT INTO RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
    (1, 1, 1, 1, 0.75, 5000, 5500, 500, '2022-04-01', '2022-04-05', 5, 175.00, 0.15, 'Completed', 'Regular customer'),
    (2, 2, 2, 2, 0.90, 6000, 6500, 500, '2022-04-02', '2022-04-04', 3, 105.00, 0.15, 'Completed', 'Special discount applied'),
    (3, 3, 3, 3, 0.80, 5500, 6000, 500, '2022-04-03', '2022-04-06', 4, 200.00, 0.15, 'Completed', 'Corporate account');
