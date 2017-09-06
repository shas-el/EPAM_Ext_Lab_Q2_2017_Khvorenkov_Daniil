CREATE PROCEDURE [dbo].[GetSections]
AS
	SELECT SectionId
		, SectionName
		, ParentSectionId
	From Section
