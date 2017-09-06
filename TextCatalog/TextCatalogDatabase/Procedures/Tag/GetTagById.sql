CREATE PROCEDURE [GetTagById]
	@tagId int
AS
	Select TagId
	, TagName
	, TagDescription
	, CategoryId
	From Tag
	Where TagId = @tagId