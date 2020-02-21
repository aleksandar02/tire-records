CREATE TABLE [dbo].[Vehicle]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ClientId] INT NULL,
    [Brand] NVARCHAR(50) NULL, 
    [Model] NVARCHAR(50) NULL, 
    [RegistrationNumber] NVARCHAR(128) NULL, 
    [Chassis] NVARCHAR(128) NULL, 

    CONSTRAINT [FK_Vehicle_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
)
