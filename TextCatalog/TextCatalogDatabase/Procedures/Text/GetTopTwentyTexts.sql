CREATE PROCEDURE [dbo].[GetTopTwentyTexts]
AS
	Select Top (20) t.TextId
		, t.TextTitle
		, t.TextDescription
		, t.UploaderId
		, t.UploadDate
		, t.FileName
		, t.SectionId
		, COUNT(*) as l
	From Text t
	Left Join Rating r
	On  t.TextId = r.TextId
	Where r.Positive = 1
	Group By t.TextId, t.TextTitle, t.TextDescription, t.UploaderId, t.UploadDate, t.FileName, t.SectionId
	Order By l desc
