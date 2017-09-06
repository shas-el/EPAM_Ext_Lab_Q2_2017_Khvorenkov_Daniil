CREATE PROCEDURE [dbo].[GetRatingsByText]
	@textId int
AS
	Select UserId
		, TextId
		, Positive
		, RatingDate
	From Rating
	Where TextId = @textId