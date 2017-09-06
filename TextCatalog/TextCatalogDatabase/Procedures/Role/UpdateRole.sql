CREATE PROCEDURE [dbo].[UpdateRole]
	@roleId int
	, @roleName nvarchar(max)
AS
	Update Role
	Set RoleName = @roleName
	Where RoleId = @roleId