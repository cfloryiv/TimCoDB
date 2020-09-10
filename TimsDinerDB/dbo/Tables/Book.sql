CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(50) NOT NULL, 
    [Author] VARCHAR(50) NOT NULL, 
    [Binding] VARCHAR(50) NOT NULL, 
    [NumberPages] INT NOT NULL, 
    [PubDate] DATETIME2 NOT NULL, 
    [PersonID] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL
)
