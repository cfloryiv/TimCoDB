CREATE TABLE [dbo].[Tracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATETIME2 NOT NULL, 
    [Qty] INT NOT NULL, 
    [PersonID] VARCHAR(50) NOT NULL, 
    [Item] NVARCHAR(50) NOT NULL, 
    [Depleted] NCHAR(1) NULL, 
    [DepletedDate] DATETIME2 NULL
)
