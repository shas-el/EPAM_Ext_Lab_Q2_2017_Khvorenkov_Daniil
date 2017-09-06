CREATE PROCEDURE [GetTagsByCategory]
	@categoryId int
AS
	Select TagId
	, TagName
	, TagDescription
	, CategoryId
	From Tag
	Where CategoryId = @categoryId