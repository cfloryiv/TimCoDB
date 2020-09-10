﻿CREATE TABLE [dbo].[Course]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Platform] VARCHAR(50) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [Author] NVARCHAR(50) NOT NULL, 
    [Cost] DECIMAL NOT NULL, 
    [PersonID] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL
)
