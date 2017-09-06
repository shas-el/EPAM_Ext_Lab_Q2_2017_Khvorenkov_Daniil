CREATE PROCEDURE [dbo].[GetUserByNamePassword]
	@userName nvarchar(max)
	, @password nvarchar(max)
AS
	Select UserId
		, UserName
		, Password
		, RoleId
	From [User]
	Where UserName = @userName and Password = @password
