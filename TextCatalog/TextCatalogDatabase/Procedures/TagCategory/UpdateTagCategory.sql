CREATE PROCEDURE [dbo].[UpdateTagCategory]
	@categoryId int
	, @categoryName nvarchar(max)
AS
	Update TagCategory
	Set CategoryName = @categoryName
	Where CategoryId = @categoryId