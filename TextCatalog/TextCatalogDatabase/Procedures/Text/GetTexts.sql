CREATE PROCEDURE [GetTexts]
AS
	Select TextId
	, TextTitle
	, TextDescription
	, UploaderId
	, UploadDate
	, FileName
	, SectionId
	From Text