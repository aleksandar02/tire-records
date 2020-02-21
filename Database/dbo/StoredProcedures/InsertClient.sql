CREATE PROCEDURE [dbo].[InsertClient]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@MobilePhone NVARCHAR(50),
	@Email NVARCHAR(128),
	@ClientId INT OUTPUT

AS
	BEGIN
		INSERT INTO Client([FirstName], [LastName], [MobilePhone], [Email])
					VALUES(@FirstName, @LastName, @MobilePhone, @Email)

		SELECT @ClientId = SCOPE_IDENTITY();
	END
