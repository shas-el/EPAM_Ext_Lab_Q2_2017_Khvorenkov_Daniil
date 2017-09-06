CREATE PROCEDURE [dbo].[GetRoleById]
	@roleId int
AS
	SELECT RoleId
		, RoleName
	From Role
	Where RoleId = RoleId
