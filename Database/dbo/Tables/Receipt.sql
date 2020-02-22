﻿CREATE TABLE [dbo].[Receipt]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [VehicleId] INT NULL, 
    [ClientId] INT NULL, 
	[Number] NVARCHAR(50) NULL, 
    [UserName] NVARCHAR(256) NULL, 
    [CreatedAt] DATETIME2 NULL, 
    [Message] NVARCHAR(MAX) NULL,

	CONSTRAINT [FK_Receipt_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id]),
	CONSTRAINT [FK_Receipt_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle]([Id])

)