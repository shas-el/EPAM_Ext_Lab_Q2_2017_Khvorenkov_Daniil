CREATE PROCEDURE [dbo].[GetRatingsByUser]
	@userId int
AS
	Select UserId
		, TextId
		, Positive
		, RatingDate
	From Rating
	Where UserId = @userId
