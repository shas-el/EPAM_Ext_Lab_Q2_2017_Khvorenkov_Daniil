CREATE PROCEDURE [dbo].[GetTagsByText]
	@textId int
AS
	Select tg.TagId
		, tg.TagName
		, tg.TagDescription
		, tg.CategoryId
	From Tag tg
	Inner Join TagToText tt
	On tg.TagId = tt.TagId
	Where tt.TextId = @textId
