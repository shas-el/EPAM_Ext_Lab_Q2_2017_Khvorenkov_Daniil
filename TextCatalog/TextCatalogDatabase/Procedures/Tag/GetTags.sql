CREATE PROCEDURE [GetTags]
AS
	Select TagId
		, TagName
		, TagDescription
		, CategoryId
	From Tag
