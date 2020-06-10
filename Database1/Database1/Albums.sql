CREATE TABLE [dbo].[Albums]
(
	[Id] INT NOT NULL,
	[Title] VARCHAR(MAX),
    [Band] VARCHAR(MAX) NOT NULL, 
    [Year] INT NULL, 
    [NumOfSongs] TINYINT NULL, 
    [BandId] INT NULL FOREIGN KEY REFERENCES Bands([Id]), 
    PRIMARY KEY ([Id])
)
