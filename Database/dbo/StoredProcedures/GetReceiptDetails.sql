CREATE PROCEDURE [dbo].[GetReceiptDetails]
	@ReceiptId INT

AS
	BEGIN
		SELECT T.[Id] AS TireId
			  ,T.[Position]
			  ,T.[Brand] AS TireBrand
			  ,T.[Model] AS TireModel
			  ,T.[Index]
			  ,T.[Dimension]
			  ,T.[Depth]
			  ,T.[DOT]
			  ,R.[Id] AS ReceiptId
			  ,R.[Number]
			  ,R.[UserName]
			  ,R.[CreatedAt]
			  ,R.[Message]
			  ,V.[Id] AS VehicleId
			  ,V.[Type] AS VehicleType
			  ,V.[Brand] AS VehicleBrand
			  ,V.[Model] AS VehicleModel
			  ,V.[RegistrationNumber]
			  ,C.[Id] AS ClientId
			  ,C.[FirstName]
			  ,C.[LastName]
			  ,C.[MobilePhone]
			  ,C.[Email]

		  FROM [Tire] T
		  INNER JOIN [Receipt] R ON T.[ReceiptId] = R.[Id]
		  INNER JOIN [Vehicle] V ON T.[VehicleId] = V.[Id]
		  INNER JOIN [Client] C ON V.[ClientId] = C.[Id]

		  WHERE T.[ReceiptId] = @ReceiptId
	END