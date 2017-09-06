CREATE PROCEDURE [dbo].[GetTagCategoryById]
	@categoryId int
AS
	SELECT CategoryId
		, CategoryName
	From TagCategory
	Where CategoryId = @categoryId