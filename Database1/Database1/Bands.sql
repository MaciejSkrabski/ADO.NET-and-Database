CREATE TABLE [dbo].[Bands]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    [Name] VARCHAR(MAX) NOT NULL, 
    [Guitarist] VARCHAR(MAX) NULL, 
    [Greatest Hit] VARCHAR(MAX) NULL
)