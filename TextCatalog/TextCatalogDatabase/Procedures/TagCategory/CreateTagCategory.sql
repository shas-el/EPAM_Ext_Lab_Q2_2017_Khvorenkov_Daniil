CREATE PROCEDURE [CreateTagCategory]
	@categoryName nvarchar(max)
AS
	Insert TagCategory (CategoryName)
	Values (@categoryName);