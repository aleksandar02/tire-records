CREATE TABLE [dbo].[Tire]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ReceiptId] INT NULL, 
    [VehicleId] INT NULL, 
    [Position] INT NULL, 
    [Dimension] NVARCHAR(50) NULL, 
    [DOT] INT NULL, 
    [Depth] DECIMAL(8, 2) NULL, 
    [Brand] NVARCHAR(50) NULL, 
    [Model] NVARCHAR(50) NULL,

	[Index] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Tire_Receipt] FOREIGN KEY ([ReceiptId]) REFERENCES [Receipt]([Id]),
	CONSTRAINT [FK_Tire_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle]([Id])
)
