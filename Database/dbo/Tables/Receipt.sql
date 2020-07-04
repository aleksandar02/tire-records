CREATE TABLE [dbo].[Receipt]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [VehicleId] INT NOT NULL, 
    [ClientId] INT NOT NULL, 
	[RNumber] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(256) NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL, 
    [Message] NVARCHAR(MAX) NULL,
	[ClosedBy] NVARCHAR(256) NULL, 
    [Status] INT NOT NULL, 
    [ClosedAt] DATETIME2 NULL, 

    CONSTRAINT [FK_Receipt_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id]),
	CONSTRAINT [FK_Receipt_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle]([Id]), 
    CONSTRAINT U_RNumber UNIQUE(RNumber)

)
