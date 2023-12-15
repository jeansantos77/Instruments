USE dbFinancialInstruments;
GO

INSERT INTO Categories ([Name],[Operator],[StartValue],[EndValue]) VALUES ('Low Value', 0 , 1000000, 0)
GO
INSERT INTO Categories ([Name],[Operator],[StartValue],[EndValue]) VALUES ('Medium Value', 1 , 1000000, 5000000)
GO
INSERT INTO Categories ([Name],[Operator],[StartValue],[EndValue]) VALUES ('High Value', 2 , 5000000, 0)
GO

INSERT INTO TypeInstruments ([Name]) VALUES ('Stock')
GO
INSERT INTO TypeInstruments ([Name]) VALUES ('Bond')
GO
INSERT INTO TypeInstruments ([Name]) VALUES ('Derivative')
GO


INSERT INTO FinancialInstruments ([MarketValue],[TypeInstrument]) VALUES  (800000, 'Stock')
GO
INSERT INTO FinancialInstruments ([MarketValue],[TypeInstrument]) VALUES  (1500000, 'Bond')
GO
INSERT INTO FinancialInstruments ([MarketValue],[TypeInstrument]) VALUES  (6000000, 'Derivative')
GO
INSERT INTO FinancialInstruments ([MarketValue],[TypeInstrument]) VALUES  (300000, 'Stock')
GO

