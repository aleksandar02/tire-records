CREATE TABLE [dbo].[Tire]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ReceiptId] INT NOT NULL, 
    [VehicleId] INT NOT NULL, 
    [Position] INT NOT NULL, 
    [Dimension] NVARCHAR(50) NOT NULL, 
    [DOT] INT NOT NULL, 
    [Depth] DECIMAL(8, 2) NOT NULL, 
    [Brand] NVARCHAR(50) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL,

	[Index] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Tire_Receipt] FOREIGN KEY ([ReceiptId]) REFERENCES [Receipt]([Id]),
	CONSTRAINT [FK_Tire_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle]([Id])
)
