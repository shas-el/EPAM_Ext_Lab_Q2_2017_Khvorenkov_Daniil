CREATE PROCEDURE [dbo].[CreateUser]
	@userName nvarchar(max)
	, @password nvarchar(max)
	, @roleId int
AS
	Insert [User] (UserName
		, Password
		, RoleId)
	Values (@userName
		, @password
		, @roleId)
