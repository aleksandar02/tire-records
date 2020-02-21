CREATE PROCEDURE [dbo].[InsertVehicle]
	@Brand NVARCHAR(50),
	@RegistrationNumber NVARCHAR(50),
	@ClientId INT,
	@VehicleId INT OUTPUT

AS
	BEGIN
		INSERT INTO Vehicle([Brand], [RegistrationNumber], [ClientId])
					VALUES(@Brand, @RegistrationNumber, @ClientId)

		SELECT @VehicleId = SCOPE_IDENTITY();
	END
