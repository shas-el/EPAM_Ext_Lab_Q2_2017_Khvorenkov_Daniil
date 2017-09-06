CREATE PROCEDURE [dbo].[GetTagToTextByText]
	@textId int
AS
	Select TagId
		, TextId
	From TagToText
	Where TextId = @textId
