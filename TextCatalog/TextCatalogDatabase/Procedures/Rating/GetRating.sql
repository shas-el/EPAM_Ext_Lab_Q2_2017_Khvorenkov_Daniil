CREATE PROCEDURE [dbo].[GetRating]
	@textId int
	, @userId int
AS
	Select UserId
		, TextId
		, Positive
		, RatingDate
	From Rating
	Where TextId = @textId and UserId = @userId