CREATE TABLE [dbo].[Vehicle]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ClientId] INT NOT NULL,
    [Brand] NVARCHAR(50) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL, 
    [RegistrationNumber] NVARCHAR(128) NOT NULL, 
    [Chassis] NVARCHAR(128) NOT NULL, 
    [Type] INT NOT NULL, 

    CONSTRAINT [FK_Vehicle_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
)
