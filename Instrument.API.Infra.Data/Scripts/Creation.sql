
CREATE DATABASE dbFinancialInstruments;
GO

USE dbFinancialInstruments;
GO


CREATE TABLE FinancialInstruments 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MarketValue FLOAT NOT NULL,
    TypeInstrument VARCHAR(50) NOT NULL,
	CategoryName VARCHAR(50),
	DateProcessed DATETIME2
)
GO


CREATE TABLE Categories(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(250) NOT NULL,
	Operator INT NOT NULL,
	StartValue FLOAT NOT NULL,
	EndValue FLOAT NULL
)
GO


CREATE TABLE TypeInstruments
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(250) NOT NULL,
)
GO

