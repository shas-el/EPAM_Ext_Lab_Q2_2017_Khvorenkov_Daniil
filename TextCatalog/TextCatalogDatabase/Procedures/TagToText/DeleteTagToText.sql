CREATE PROCEDURE [dbo].[DeleteTagToText]
	@tagId int
	, @textId int
AS
	Delete 
	From TagToText
	Where TagId = @tagId and TextId = @textId

