CREATE PROCEDURE [dbo].[InsertVehicle]
	@Type INT,
	@Brand NVARCHAR(50),
	@RegistrationNumber NVARCHAR(50),
	@ClientId INT,
	@VehicleId INT OUTPUT

AS
	BEGIN
		INSERT INTO Vehicle([Brand], [RegistrationNumber], [ClientId], [Type])
					VALUES(@Brand, @RegistrationNumber, @ClientId, @Type)

		SELECT @VehicleId = SCOPE_IDENTITY();
	END
