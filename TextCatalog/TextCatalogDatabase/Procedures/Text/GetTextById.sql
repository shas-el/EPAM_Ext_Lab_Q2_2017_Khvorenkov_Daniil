CREATE PROCEDURE [GetTextById]
	@textId int
AS
	Select TextId
	, TextTitle
	, TextDescription
	, UploaderId
	, UploadDate
	, FileName
	, SectionId
	From Text
	Where TextId = @textId
