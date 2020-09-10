CREATE TABLE [dbo].[Refill]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Doctor] VARCHAR(50) NOT NULL, 
    [Cost] DECIMAL NOT NULL, 
    [PillSize] VARCHAR(50) NOT NULL, 
    [Period] INT NOT NULL, 
    [PersonID] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL
)
