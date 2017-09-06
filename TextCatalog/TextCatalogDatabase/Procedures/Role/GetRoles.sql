CREATE PROCEDURE [dbo].[GetRoles]
AS
	SELECT RoleId
		, RoleName
	From Role