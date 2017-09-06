CREATE PROCEDURE [dbo].[GetTextsQuery]
	@titleString nvarchar = null
	, @descrString nvarchar = null
	, @sectionId int = null
	, @beginDate datetime = null
	, @endDate datetime = null
	, @uploaderId int = null
AS
	Declare @sections table(SectionId int
		, SectionName nvarchar(max)
		, ParentSectionId int)
	Insert into @sections exec GetSectionAndDescendants @sectionId
	Select TextId
		, TextTitle
		, TextDescription
		, UploaderId
		, UploadDate
		, FileName
		, SectionId
	From Text
	Where (@titleString is Null Or
		TextTitle Like '%' + @titleString + '%')
		And
		(@descrString is Null Or
		TextDescription Like '%' + @descrString + '%')
		And
		(@sectionId is Null Or
		SectionId in (Select SectionId From @sections))
		And
		(@beginDate is Null Or
		UploadDate > @beginDate)
		And
		(@endDate is Null Or
		UploadDate < @endDate)
		And
		(@uploaderId is Null Or
		UploaderId = @uploaderId)
