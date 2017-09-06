CREATE PROCEDURE [dbo].[GetTagToTextByTag]
	@tagId int
AS
	Select TagId
		, TextId
	From TagToText
	Where TagId = @tagId