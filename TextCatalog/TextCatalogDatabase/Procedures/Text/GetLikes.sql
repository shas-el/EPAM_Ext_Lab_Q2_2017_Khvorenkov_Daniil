CREATE PROCEDURE [dbo].[GetLikes]
	@textId int
AS
	Select Count(*)
	From Rating
	Where TextId = @textId
	And Positive = 1
