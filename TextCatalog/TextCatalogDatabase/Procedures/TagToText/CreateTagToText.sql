CREATE PROCEDURE [dbo].[CreateTagToText]
	@tagId int
	, @textId int
AS
	Insert TagToText (TagId
		, TextId)
	Values (@tagId
		, @textId)
