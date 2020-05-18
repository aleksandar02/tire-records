CREATE PROCEDURE [dbo].[GetLastReceiptId]
	@Year INT
AS
	BEGIN
		SELECT COUNT([Id])
		FROM Receipt
		WHERE YEAR(CreatedAt) = @Year
	END
	