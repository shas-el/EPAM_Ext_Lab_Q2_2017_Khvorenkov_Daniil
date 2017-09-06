CREATE PROCEDURE [dbo].[GetUserById]
	@userId int
AS
	SELECT UserId
		, UserName
		, Password
		, RoleId
	From [User]
	Where UserId = @userId
