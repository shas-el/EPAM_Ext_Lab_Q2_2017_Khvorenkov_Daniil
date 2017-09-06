CREATE PROCEDURE [dbo].[UpdateUser]
	@userId int
	, @userName nvarchar(max)
	, @password nvarchar(max)
	, @roleId int
AS
	Update [User]
	Set UserName = @userName
		, Password = @password
		, RoleId = @roleId
	Where UserId = @userId