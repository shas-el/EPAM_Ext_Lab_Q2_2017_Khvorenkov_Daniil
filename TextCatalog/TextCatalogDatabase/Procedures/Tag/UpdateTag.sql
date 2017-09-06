CREATE PROCEDURE [UpdateTag]
	@tagId int
	, @tagName nvarchar(max)
	, @tagDescription nvarchar(max)
	, @categoryId int
AS
	Update Tag
	Set TagName = @tagName
		, TagDescription = @tagDescription
		, CategoryId = CategoryId
	Where TagId = @tagId