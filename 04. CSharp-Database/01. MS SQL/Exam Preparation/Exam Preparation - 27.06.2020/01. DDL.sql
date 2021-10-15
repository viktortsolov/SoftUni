CREATE DATABASE WashingMachineService

GO

USE WashingMachineService
GO

CREATE TABLE Vendors (
	[VendorId] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Mechanics (
	[MechanicId] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,	
	[LastName] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(255) NOT NULL
)

CREATE TABLE Clients (
	[ClientId] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,	
	[LastName] NVARCHAR(50) NOT NULL,
	[Phone] CHAR(12) NOT NULL
)

CREATE TABLE Models (
	[ModelId] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts (
	[PartId] INT PRIMARY KEY IDENTITY NOT NULL,
	[SerialNumber] NVARCHAR(50) UNIQUE NOT NULL,
	[Description] NVARCHAR(255),
	[Price] MONEY NOT NULL,
	CONSTRAINT [Price_CHECK] CHECK ([Price] > 0),
	[VendorId] INT FOREIGN KEY REFERENCES [Vendors]([VendorId]),
	[StockQty] INT NOT NULL DEFAULT 0,
	CONSTRAINT [StockQty_CHECK] CHECK ([StockQty] >= 0)
)

CREATE TABLE Jobs (
	[JobId] INT PRIMARY KEY IDENTITY NOT NULL,
	[ModelId] INT FOREIGN KEY REFERENCES [Models]([ModelId]),
	[Status] NVARCHAR(11) NOT NULL DEFAULT 'Pending',
	CONSTRAINT [Status_CHECK] CHECK ([Status] IN ('Pending', 'In Progress', 'Finished')),
	[ClientId] INT FOREIGN KEY REFERENCES [Clients]([ClientId]),
	[MechanicId] INT FOREIGN KEY REFERENCES [Mechanics]([MechanicId]),
	[IssueDate] DATE NOT NULL,
	[FinishDate] DATE
)

CREATE TABLE Orders (
	[OrderId] INT PRIMARY KEY IDENTITY,
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]),
	[IssueDate] DATE,
	[Delivered] BIT NOT NULL DEFAULT 0
)

CREATE TABLE PartsNeeded (
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) IDENTITY,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]),
	[Quantity] INT NOT NULL DEFAULT 1,
	CONSTRAINT [QuantityParts_CHECK] CHECK ([Quantity] > 0),
	PRIMARY KEY([JobId], [PartId])
)

CREATE TABLE OrderParts (
	[OrderId] INT FOREIGN KEY REFERENCES [Orders]([OrderId]) IDENTITY,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]),
	[Quantity] INT NOT NULL DEFAULT 1,
	CONSTRAINT [QuantityOrders_CHECK] CHECK ([Quantity] > 0),
	PRIMARY KEY([OrderId], [PartId])
)