CREATE PROCEDURE [dbo].[CloseReceipt]
	@Id INT,
	@ClosedBy NVARCHAR(256),
	@ClosedAt DATETIME2(7)

	AS
		BEGIN
			UPDATE Receipt SET ClosedBy = @ClosedBy, ClosedAt = @ClosedAt, [Status] = 2 WHERE Id = @Id
		END