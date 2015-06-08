CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [KoffieNaam] NVARCHAR(50) NOT NULL, 
    [Landschap] NVARCHAR(50) NOT NULL, 
    [Tijd] TIMESTAMP NOT NULL, 
    [Sterkte] INT NOT NULL, 
    [Suiker] INT NOT NULL, 
    [Melk] INT NOT NULL, 
    [DeviceID] INT NOT NULL
)
