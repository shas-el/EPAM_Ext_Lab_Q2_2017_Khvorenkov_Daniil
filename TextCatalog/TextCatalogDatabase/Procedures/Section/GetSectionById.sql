CREATE PROCEDURE [dbo].[GetSectionById]
	@sectionId int
AS
	SELECT SectionId
		, SectionName
		, ParentSectionId
	From Section
	Where SectionId = @sectionId