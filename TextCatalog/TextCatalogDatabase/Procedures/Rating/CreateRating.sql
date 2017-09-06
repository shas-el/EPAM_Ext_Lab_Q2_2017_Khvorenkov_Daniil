CREATE PROCEDURE [dbo].[CreateRating]
	@userID int
	, @textId int
	, @positive bit
	, @ratingDate datetime
AS
	Insert Rating (UserId
		, TextId
		, Positive
		, RatingDate)
	Values (@userID
		, @textId
		, @positive
		, @ratingDate)
