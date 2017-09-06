CREATE PROCEDURE [dbo].[CreateRole]
	@roleName nvarchar(max)
AS
	Insert Role (RoleName)
	Values (@roleName);