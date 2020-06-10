CREATE TABLE [dbo].[RockMusic]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    [Band] VARCHAR(MAX) NOT NULL, 
    [Album] VARCHAR(MAX) NULL, 
    [Guitarist] VARCHAR(MAX) NULL, 
    [Greatest Hit] VARCHAR(MAX) NULL
)
