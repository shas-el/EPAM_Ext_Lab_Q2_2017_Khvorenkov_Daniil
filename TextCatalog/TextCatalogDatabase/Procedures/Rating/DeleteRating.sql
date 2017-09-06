CREATE PROCEDURE [dbo].[DeleteRating]
	@userId int
	, @textId int
AS
	Delete
	From Rating
	Where UserId = @userId and TextId = @textId
