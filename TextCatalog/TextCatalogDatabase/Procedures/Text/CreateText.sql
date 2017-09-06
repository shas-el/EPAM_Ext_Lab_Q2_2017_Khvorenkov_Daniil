CREATE PROCEDURE [CreateText]
	@textTitle nvarchar(max),
	@textDescription nvarchar(max),
	@uploaderId int,
	@uploadDate datetime,
	@fileName nvarchar(max),
	@sectionId int
AS
	Insert [Text] (TextTitle
		, TextDescription
		, UploaderId
		, UploadDate
		, FileName
		, SectionId)
	Values (@textTitle
		, @textDescription
		, @uploaderId
		, @uploadDate
		, @fileName
		, @sectionId)