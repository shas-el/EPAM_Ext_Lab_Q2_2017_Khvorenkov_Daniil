CREATE PROCEDURE [dbo].[DeleteTagCategory]
	@categoryId int
AS
	Delete
	From TagCategory
	Where CategoryId = @categoryId