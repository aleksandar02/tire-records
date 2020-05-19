CREATE PROCEDURE [dbo].[GetDataCount]
AS
	BEGIN
		SELECT COUNT(Receipt.Id) AS ReceiptsCount,
			   (SELECT COUNT(Vehicle.Id) FROM Vehicle WHERE Vehicle.Type = 1) AS VehicleType1Count,
			   (SELECT COUNT(Vehicle.Id) FROM Vehicle WHERE Vehicle.Type = 2) AS VehicleType2Count

		FROM Receipt
	END