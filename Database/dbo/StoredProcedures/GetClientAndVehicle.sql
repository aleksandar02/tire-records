CREATE PROCEDURE [dbo].[GetClientAndVehicle]
	@VehicleId INT
AS
	BEGIN
		SELECT 
			V.[Id] AS VehicleId,
			V.[Type] AS VehicleType, 
			V.[Brand] AS VehicleBrand,
			V.[Model] AS VehicleModel,
			V.[RegistrationNumber],
			C.[Id] AS ClientId,
			C.[FirstName],
			C.[LastName],
			C.[MobilePhone],
			C.[Email]

			FROM [Vehicle] V
			INNER JOIN [Client] C ON C.[Id] = V.[ClientId]
			WHERE V.[Id] = @VehicleId
	END
	