CREATE PROCEDURE [dbo].[GetUsers]
AS
	SELECT UserId
		, UserName
		, Password
		, RoleId
	From [User]
