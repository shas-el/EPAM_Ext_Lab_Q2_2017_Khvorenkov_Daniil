CREATE PROCEDURE [dbo].[GetDislikes]
	@textId int
AS
	Select Count(*)
	From Rating
	Where TextId = @textId
	And Positive = 0