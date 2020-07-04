CREATE PROCEDURE [dbo].[InsertReceipt]
	@RNumber NVARCHAR(50),
	@Message NVARCHAR(MAX),
	@UserName NVARCHAR(256),
	@CreatedAt DATETIME2(7),
	@VehicleId INT,
	@ClientId INT,
	@ReceiptId INT OUTPUT,
	@Status INT

AS
	BEGIN
		INSERT INTO Receipt([RNumber], [Message], [UserName], [CreatedAt], [VehicleId], [ClientId], [Status], [ClosedAt])
					VALUES(@RNumber, @Message, @UserName, @CreatedAt, @VehicleId, @ClientId, @Status, NULL)

		SELECT @ReceiptId = SCOPE_IDENTITY();
	END
