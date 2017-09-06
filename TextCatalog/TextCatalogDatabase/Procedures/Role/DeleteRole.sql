CREATE PROCEDURE [dbo].[DeleteRole]
	@roleId int
AS
	Delete
	From Role
	Where RoleId = RoleId;