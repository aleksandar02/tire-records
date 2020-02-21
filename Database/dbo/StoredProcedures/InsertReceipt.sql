CREATE PROCEDURE [dbo].[InsertReceipt]
	@Number INT,
	@Message NVARCHAR(MAX),
	@UserName NVARCHAR(256),
	@CreatedAt DATETIME2(7),
	@VehicleId INT,
	@ClientId INT,
	@ReceiptId INT OUTPUT

AS
	BEGIN
		INSERT INTO Receipt([Number], [Message], [UserName], [CreatedAt], [VehicleId], [ClientId])
					VALUES(@Number, @Message, @UserName, @CreatedAt, @VehicleId, @ClientId)

		SELECT @ReceiptId = SCOPE_IDENTITY();
	END
