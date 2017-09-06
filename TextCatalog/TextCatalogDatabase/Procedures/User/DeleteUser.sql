CREATE PROCEDURE [dbo].[DeleteUser]
	@userId int
AS
	Delete
	From [User]
	Where UserId = @userId
