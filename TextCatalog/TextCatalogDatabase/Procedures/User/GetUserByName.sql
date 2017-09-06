CREATE PROCEDURE [dbo].[GetUserByName]
	@userName nvarchar(max)
AS
	Select UserId
		, UserName
		, Password
		, RoleId
	From [User]
	Where UserName = @userName