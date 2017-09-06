CREATE PROCEDURE [dbo].[GetTextsByTag]
	@tagId int
AS
	SELECT tx.TextId
		, tx.TextTitle
		, tx.TextDescription
		, tx.UploadDate
		, tx.UploaderId
		, tx.SectionId
		, tx.FileName
	From Text tx
	Inner Join TagToText tt
	On tx.TextId = tt.TextId
	Where tt.TagId = @tagId
