CREATE PROCEDURE [dbo].[InsertTire]
	@Position INT,
	@Brand NVARCHAR(50),
	@Model NVARCHAR(50),
	@Dimension NVARCHAR(50),
	@Index NVARCHAR(50),
	@DOT INT,
	@Depth DECIMAL(8,1),
	@VehicleId INT,
	@ReceiptId INT


AS
	BEGIN
		INSERT INTO Tire([Position], [Brand], [Model], [Dimension], [Index], [DOT], [Depth], [VehicleId], [ReceiptId])
				  VALUES(@Position, @Brand, @Model, @Dimension, @Index, @DOT, @Depth, @VehicleId, @ReceiptId)

	END
