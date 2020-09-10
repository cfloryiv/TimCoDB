CREATE TABLE [dbo].[Ledger]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccountNumber] NCHAR(10) NOT NULL, 
    [ClassID] NCHAR(10) NOT NULL, 
    [Year] INT NOT NULL, 
    [Budget] MONEY NULL, 
    [Actual] MONEY NULL
)
