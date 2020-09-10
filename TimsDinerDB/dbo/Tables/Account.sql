CREATE TABLE [dbo].[Account]
(
	[AccountNumber] NCHAR(10) NOT NULL, 
    [ClassID] NCHAR(10) NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [Type] CHAR NOT NULL,
    constraint ID primary key (AccountNumber, ClassID)
)
