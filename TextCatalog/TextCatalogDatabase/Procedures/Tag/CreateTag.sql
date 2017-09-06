CREATE PROCEDURE [CreateTag]
	@tagName nvarchar(max)
	, @tagDescription nvarchar(max)
	, @categoryId int
AS
	Insert [Tag] (TagName
		, TagDescription
		, CategoryId)
	Values (@tagName
		, @tagDescription
		, @categoryId);