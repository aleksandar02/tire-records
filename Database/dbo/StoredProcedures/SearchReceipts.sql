﻿CREATE PROCEDURE [dbo].[SearchReceipts]
(
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@RegistrationNumber NVARCHAR(128),
	@DateFrom DATETIME2(7),
	@DateTo DATETIME2(7),
	@VehicleType INT,
	@RNumber NVARCHAR(50),
	@Status INT
)

AS 
	BEGIN
		SELECT DISTINCT
			C.[Id] AS ClientId,
			C.[FirstName],
			C.[LastName],
			C.[MobilePhone],
			C.[Email],
			V.[Id] AS VehicleId,
			V.[Type] AS VehicleType, 
			V.[Brand] AS VehicleBrand,
			V.[Model] AS VehicleModel,
			V.[RegistrationNumber],
			R.[Id] AS ReceiptId,
			R.[RNumber],
			R.[UserName],
			R.[Message],
			R.[CreatedAt],
			R.[ClosedBy],
			R.[ClosedAt],
			R.[Status]
		
		FROM [Receipt] R
		INNER JOIN [Client] C ON R.[ClientId] = C.Id
		INNER JOIN [Vehicle] V ON R.[VehicleId] = V.Id

		WHERE (R.[CreatedAt] >= @DateFrom AND R.[CreatedAt] <= @DateTo) AND
			  (C.[FirstName] LIKE @FirstName + '%' OR @FirstName = '') AND
			  (C.[LastName] LIKE @LastName + '%' OR @LastName = '') AND 
			  (R.[RNumber] LIKE @RNumber + '%' OR @RNumber = '') AND
			  (V.[RegistrationNumber] = @RegistrationNumber OR @RegistrationNumber = '') AND
			  (V.[Type] = @VehicleType OR @VehicleType = -1) AND
			  (R.[Status] = @Status OR @Status = -1) 

		ORDER BY R.[CreatedAt] DESC
	END