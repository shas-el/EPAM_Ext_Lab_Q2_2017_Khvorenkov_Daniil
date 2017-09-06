CREATE PROCEDURE [UpdateText]
	@textId int,
	@textTitle nvarchar(max),
	@textDescription nvarchar(max),
	@uploaderId int,
	@uploadDate datetime,
	@fileName nvarchar(max),
	@sectionId int
AS
	Update [Text]
	Set TextTitle = @textTitle,
		TextDescription = @textDescription,
		UploaderId = @uploaderId,
		UploadDate = @uploadDate,
		FileName = @fileName,
		SectionId = @sectionId
	Where TextId = @textId