CREATE PROCEDURE [dbo].[CreateSection]
	@sectionName nvarchar(max)
	, @parentSectionId int
AS
	Insert Section (SectionName
		, ParentSectionId)
	Values (@sectionName
		, @parentSectionId);