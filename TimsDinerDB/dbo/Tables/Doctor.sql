﻿CREATE TABLE [dbo].[Doctor]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Hospital] VARCHAR(50) NOT NULL, 
    [TelNo] VARCHAR(50) NOT NULL, 
    [Speciality] VARCHAR(50) NOT NULL
)
