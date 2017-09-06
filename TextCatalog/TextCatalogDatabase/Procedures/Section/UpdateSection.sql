CREATE PROCEDURE [dbo].[UpdateSection]
	@sectionId int
	, @sectionName nvarchar(max)
	, @parentSectionId int
AS
	Update Section
	Set SectionName = @sectionName
		, ParentSectionId = @parentSectionId
	Where SectionId = @sectionId