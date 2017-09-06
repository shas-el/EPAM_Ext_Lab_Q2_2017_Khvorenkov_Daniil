CREATE PROCEDURE [GetTextsByUploader]
	@uploaderID int
AS
	Select TextId
	, TextTitle
	, TextDescription
	, UploaderId
	, UploadDate
	, FileName
	, SectionId
	From Text
	Where UploaderId = @uploaderID
