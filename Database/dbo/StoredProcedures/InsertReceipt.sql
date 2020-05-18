CREATE PROCEDURE [dbo].[InsertReceipt]
	@RNumber NVARCHAR(50),
	@Message NVARCHAR(MAX),
	@UserName NVARCHAR(256),
	@CreatedAt DATETIME2(7),
	@VehicleId INT,
	@ClientId INT,
	@ReceiptId INT OUTPUT

AS
	BEGIN
		INSERT INTO Receipt([RNumber], [Message], [UserName], [CreatedAt], [VehicleId], [ClientId])
					VALUES(@RNumber, @Message, @UserName, @CreatedAt, @VehicleId, @ClientId)

		SELECT @ReceiptId = SCOPE_IDENTITY();
	END
