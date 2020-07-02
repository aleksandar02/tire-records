CREATE PROCEDURE [dbo].[InsertReceipt]
	@RNumber NVARCHAR(50),
	@Message NVARCHAR(MAX),
	@UserName NVARCHAR(256),
	@CreatedAt DATETIME2(7),
	@VehicleId INT,
	@ClientId INT,
	@ReceiptId INT OUTPUT,
	@Status INT,
	@ClosedAt DATETIME2(7)

AS
	BEGIN
		INSERT INTO Receipt([RNumber], [Message], [UserName], [CreatedAt], [VehicleId], [ClientId], [Status], [ClosedAt])
					VALUES(@RNumber, @Message, @UserName, @CreatedAt, @VehicleId, @ClientId, @Status, @ClosedAt)

		SELECT @ReceiptId = SCOPE_IDENTITY();
	END
