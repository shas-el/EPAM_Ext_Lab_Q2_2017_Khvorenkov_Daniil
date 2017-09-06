CREATE PROCEDURE [DeleteTag]
	@tagId int
AS
	Delete
	From TagToText
	Where TagId = @tagId;
	Delete
	From Tag
	Where TagId = @tagId;